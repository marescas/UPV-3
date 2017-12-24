(defglobal ?*nod-gen* = 0)
(deffacts datos 
(nodoBici A B K H J M N R )
(nodoNormal C D E F G I L O P Q )

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

(nodoInicial A)
(nodoFinal R)
(estado actual A bici 0 coste 0 profundidad 0)
)

;;===================================================================
;;Regla parada,
;; 1) nodoActual debe ser igual a nodoFinal 
;; 2) El usuario no debe tener bicicleta o lo que es lo mismo, b = 0
;;===================================================================

(defrule parada
(declare(salience 100))
(nodoFinal ?x)
(estado actual ?a bici ?b coste ?c profundidad ?p )
(test(and(eq ?x ?a)(eq ?b 0)))
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
(nodoBici $?x ?p $?y)
(profundidad-maxima ?prof)
(estado actual ?a bici ?b coste ?c profundidad ?px )
(test(and(eq ?a ?p)(eq ?b 0)(< ?px ?prof ))) ;;el nodo actual es parte de los nodos aptos para coger bicicleta y no lleva bicicleta.
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
(nodoBici $?x ?p $?y)
(profundidad-maxima ?prof)
(estado actual ?a bici ?b coste ?c profundidad ?px)
(test(and(eq ?a ?p)(eq ?b 1)(< ?px ?prof ))) ;;el nodo actual es parte de los nodos aptos para coger bicicleta y lleva bicicleta.
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
;;=============================================================================

(defrule irPieX-Y
(estado actual ?a bici ?b coste ?c profundidad ?px)
(conectado ?a ?y ?r ?peso)
(profundidad-maxima ?prof)
(test(and(eq ?b 0)(< ?px ?prof )))
=>
(assert(estado actual ?y bici 0 coste (+ ?c ?peso) profundidad (+ 1 ?px) ))
(bind ?*nod-gen* (+ ?*nod-gen* 1))
)
(defrule irPieY-X
(estado actual ?a bici ?b coste ?c profundidad ?px)
(conectado ?x ?a ?r ?peso)
(profundidad-maxima ?prof)
(test(and(eq ?b 0)(< ?px ?prof ) ))
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
(estado actual ?a bici ?b coste ?c profundidad ?px)
(conectado ?a ?y ?r ?peso)
(profundidad-maxima ?prof)
(test(and(eq ?r 2 )(eq ?b 1)(< ?px ?prof )))
=>
(assert(estado actual ?y bici 1 coste (+ ?c (div ?peso 2)) profundidad (+ 1 ?px)))
(bind ?*nod-gen* (+ ?*nod-gen* 1))
)
(defrule irBiciY-X
(estado actual ?a bici ?b coste ?c profundidad ?px)
(conectado ?x ?a ?r ?peso)
(profundidad-maxima ?prof)
(test(and(eq ?r 2 )(eq ?b 1)(< ?px ?prof ) ))
=>
(assert(estado actual ?x bici 1 coste (+ ?c (div ?peso 2)) profundidad (+ 1 ?px)))
(bind ?*nod-gen* (+ ?*nod-gen* 1))
)

;;=============================================================================
;;Funcion inicial, carga la profundidad maxima en la BH
;;=============================================================================

(deffunction inicio()
(reset)
(printout t "Profundidad Maxima:= " )
(bind ?prof (read))
(printout t " Ejecuta run para poner en marcha el programa " crlf)
(assert (profundidad-maxima ?prof))
)