(defglobal ?*nod-gen* = 0)
(defglobal ?*f* = 0) 
(deffacts datos 
(nodoBici A SI)
(nodoBici B SI)
(nodoBici K SI)
(nodoBici H SI)
(nodoBici J SI)
(nodoBici M SI)
(nodoBici N SI)
(nodoBici R SI)
(nodoBici C NO)
(nodoBici D NO)
(nodoBici E NO)
(nodoBici F NO)
(nodoBici G NO)
(nodoBici I NO)
(nodoBici L NO)
(nodoBici O NO)
(nodoBici P NO)
(nodoBici Q NO)


;;==================================================================
;; (conectado X Y (1:2) p )X va a Y (1:andando 2:bici)  con peso p
;;==================================================================

(conectado A B 2 10)
(conectado A C 1 8)
(conectado A E 2 10)
(conectado B F 1 6)
(conectado B C 1 5)
(conectado C D 1 6)
(conectado C G 1 6)
(conectado C H 1 6)
(conectado D H 2 14)
(conectado H G 1 8)
(conectado H I 2 12)
(conectado I E 1 20)
(conectado E J 2 9)
(conectado J O 2 7)
(conectado O I 1 2)
(conectado O N 2 8)
(conectado N Q 1 6)
(conectado Q M 1 2)
(conectado Q R 1 3)
(conectado Q P 1 2)
(conectado P R 2 4)
(conectado P L 2 6)
(conectado L K 2 2)
(conectado L M 2 7)
(conectado M G 1 12)
(conectado G L 1 9)
(conectado L F 1 6)
(conectado F K 1 10)

(Barrio 1 A)
(Barrio 2 B)
(Barrio 2 C)
(Barrio 2 D)
(Barrio 2 E)
(Barrio 2 J)
(Barrio 3 F)
(Barrio 3 G)
(Barrio 3 H)
(Barrio 3 I)
(Barrio 3 O)

(Barrio 4 K)
(Barrio 4 L)
(Barrio 4 M)
(Barrio 4 N)
(Barrio 5 P)
(Barrio 5 Q)
(Barrio 6 R)

(Min A 8)
(Min B 5)
(Min C 6)
(Min D 6)
(Min E 9)
(Min F 6)
(Min G 6)
(Min H 6)
(Min I 2)
(Min J 7)
(Min K 2)
(Min L 6)
(Min M 2)
(Min N 6)
(Min O 2)
(Min P 2)
(Min Q 2)
(Min R 3)



(nodoFinal R)
(estado actual A bici 0 coste 0 profundidad 0)
)

;;=============================================================================
;;Funcion heuristica, calcula h(n)
;; |b1-b2| min 1 TODO 
;; min(caminos(n))
;; sit = 0,5 si lleva bicicletas o esta en un punto de bicicletas sino 1
;;=============================================================================
(deffunction heuristica(?b1 ?b2 ?min ?bici ?flag)
(bind ?resultado 0)
(bind ?DistBarrios (abs (- ?b1 ?b2)))
(bind ?minDist ?min)
(bind ?bike 0.0)
(if (eq 0 ?DistBarrios)
then (bind ?resultado 1)
else
(bind ?resultado ?DistBarrios)
)
(bind ?resultado (* ?resultado ?minDist)) ;DistBarrios * minCamino(n)
(if (or(eq ?bici 1)(eq ?flag SI))
then (bind ?bike 0.5) else (bind ?bike 1.0) )
(bind ?resultado (* ?resultado ?bike)) ;g(n)
?resultado

)

;;=============================================================================
;;Funcion control, lanza la función heuristica y añade el valor al salience.
;; f(n) = h(n) + g(n) 
;;=============================================================================
(deffunction control(?c ?b1 ?b2 ?min ?bici ?flag)
(bind ?*f* (heuristica ?b1 ?b2 ?min ?bici ?flag))
(bind ?*f* (+ ?*f* ?c)) 
(bind ?*f* (div ?*f* 1)) ;tiene que ser un valor entero, div es la división entera
)


;;===================================================================
;;Regla parada,
;; 1) nodoActual debe ser igual a nodoFinal 
;; 2) El usuario no debe tener bicicleta o lo que es lo mismo, b = 0
;;===================================================================

(defrule parada
(declare (salience (- 0 ?*f*)))
(nodoFinal ?x)
(estado actual ?a bici ?b coste ?c profundidad ?p )
(test(and(eq ?x ?a)(eq ?b 0)))

(nodoFinal ?nodoF)
(Barrio ?b1 ?a )
(Barrio ?b2 ?nodoF)
(Min ?a ?min)
(nodoBici ?a ?estado)
(test (control  ?c  ?b1 ?b2 ?min 0 ?estado))
=>
(printout t "Solucion encontrada " crlf)
(printout t "Profundidad "?p crlf)
(printout t "Coste " ?c crlf)
(printout t "Nodos Generados " ?*nod-gen* crlf)
(halt)
)

;;===================================================================
;; Regla para coger bicicleta
;; 1) El nodo actual debe pertenecer al conjunto de bicicletas
;; 2) El usuario no debe llevar bicicleta o lo que es lo mismo b =0 
;;===================================================================

(defrule coger_bici 
(declare (salience (- 0 ?*f*)))
(profundidad-maxima ?prof)
(estado actual ?a bici ?b coste ?c profundidad ?px )
(nodoBici ?a SI )
(test(and(eq ?b 0)(< ?px ?prof ))) ;;el nodo actual es parte de los nodos aptos para coger bicicleta y no lleva bicicleta.

(nodoFinal ?nodoF)
(Barrio ?b1 ?a )
(Barrio ?b2 ?nodoF)
(Min ?a ?min)
(test (control (+ ?c 1) ?b1 ?b2 ?min 0 SI))
=>
(assert(estado actual ?a bici 1 coste (+ 1 ?c) profundidad (+ 1 ?px) ))
(bind ?*nod-gen* (+ ?*nod-gen* 1))
)

;;===================================================================
;; Regla para dejar bicicleta
;; 1) El nodo actual debe pertenecer al conjunto de bicicletas
;; 2) El usuario debe llevar bicicleta o lo que es lo mismo b =1 
;;===================================================================

(defrule dejar_bici
(declare (salience (- 0 ?*f*)))
(profundidad-maxima ?prof)
(estado actual ?a bici ?b coste ?c profundidad ?px)
(nodoBici ?a SI )
(test(and(eq ?b 1)(< ?px ?prof ))) ;;el nodo actual es parte de los nodos aptos para coger bicicleta y lleva bicicleta.

(nodoFinal ?nodoF)
(Barrio ?b1 ?a )
(Barrio ?b2 ?nodoF)
(Min ?a ?min)
(test (control (+ ?c 1) ?b1 ?b2 ?min 1 SI))

=>
(assert(estado actual ?a bici 0 coste (+ 1 ?c) profundidad (+ 1 ?px)))
(bind ?*nod-gen* (+ ?*nod-gen* 1))
)

;;=============================================================================
;;Reglas que definen las acciones ir a pie de X a Y y de Y a X
;;Para ello debe cumplirse: 
;;1) X este conectado con Y o Y con X, 
;;2) No tenga bici, o lo que es lo mismo bici 0 
;;3) La profundidad sea menor que la profundidad maxima.
;; ------HEURISTICA------
;; a la funcion de control le pasamos:
;; el coste,
;; los barrios,
;; el minimo de los caminos,
;; y si es nodo de bicicletas
;;
;;=============================================================================

(defrule irPieX-Y
(declare (salience (- 0 ?*f*)))
(estado actual ?a bici ?b coste ?c profundidad ?px)
(conectado ?a ?y ?r ?peso)
(profundidad-maxima ?prof)
(test(and(eq ?b 0)(< ?px ?prof )))

(nodoFinal ?nodoF)
(Barrio ?b1 ?a )
(Barrio ?b2 ?nodoF)
(Min ?a ?min)
(nodoBici ?a ?estado)
(test (control (+ ?c ?peso) ?b1 ?b2 ?min 0 ?estado))


=>
(assert(estado actual ?y bici 0 coste (+ ?c ?peso) profundidad (+ 1 ?px) ))
(bind ?*nod-gen* (+ ?*nod-gen* 1))
)
(defrule irPieY-X
(declare (salience (- 0 ?*f*)))
(estado actual ?a bici ?b coste ?c profundidad ?px)
(conectado ?x ?a ?r ?peso)
(profundidad-maxima ?prof)
(test(and(eq ?b 0)(< ?px ?prof ) ))

(nodoFinal ?nodoF)
(Barrio ?b1 ?a )
(Barrio ?b2 ?nodoF)
(Min ?a ?min)
(nodoBici ?a ?estado)
(test (control (+ ?c ?peso) ?b1 ?b2 ?min 0 ?estado))
=>
(assert(estado actual ?x bici 0 coste (+ ?c ?peso) profundidad (+ 1 ?px) ))
(bind ?*nod-gen* (+ ?*nod-gen* 1))
)

;;=============================================================================
;;Reglas que definen las acciones ir en bici de X a Y y de Y a X
;;Para ello debe cumplirse: 
;;1) X este conectado con Y o Y con X, 
;;2) Tener una bici
;;3) Camino en bici 
;;4) La profundidad sea menor que la profundidad maxima
;;=============================================================================

(defrule irBiciX-Y
(declare (salience (- 0 ?*f*)))
(estado actual ?a bici ?b coste ?c profundidad ?px)
(conectado ?a ?y ?r ?peso)
(profundidad-maxima ?prof)
(test(and(eq ?r 2 )(eq ?b 1)(< ?px ?prof )))

(nodoFinal ?nodoF)
(Barrio ?b1 ?a )
(Barrio ?b2 ?nodoF)
(Min ?a ?min)
(nodoBici ?a ?estado)
(test (control (+ ?c (div ?peso 2)) ?b1 ?b2 ?min 1 ?estado))

=>
(assert(estado actual ?y bici 1 coste (+ ?c (div ?peso 2)) profundidad (+ 1 ?px)))
(bind ?*nod-gen* (+ ?*nod-gen* 1))
)
(defrule irBiciY-X
(declare (salience (- 0 ?*f*)))
(estado actual ?a bici ?b coste ?c profundidad ?px)
(conectado ?x ?a ?r ?peso)
(profundidad-maxima ?prof)
(test(and(eq ?r 2 )(eq ?b 1)(< ?px ?prof ) ))

(nodoFinal ?nodoF)
(Barrio ?b1 ?a )
(Barrio ?b2 ?nodoF)
(Min ?a ?min)
(nodoBici ?a ?estado)
(test (control (+ ?c (div ?peso 2)) ?b1 ?b2 ?min 1 ?estado))
=>
(assert(estado actual ?x bici 1 coste (+ ?c (div ?peso 2)) profundidad (+ 1 ?px)))
(bind ?*nod-gen* (+ ?*nod-gen* 1))
)

;;=============================================================================
;;Funcion inicial, carga la profundidad maxima en la BH
;;=============================================================================

(deffunction inicio()
(set-salience-evaluation when-activated)
(reset)
(printout t "Profundidad Maxima:= " )
(bind ?prof (read))
(printout t " Ejecuta run para poner en marcha el programa " crlf)
(assert (profundidad-maxima ?prof))
)

