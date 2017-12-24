(deffacts datos
(estado MI 6 CI 6 MD 0 CD 0 B I)
(barco capacidad 2)
(meta MI 0 CI 0 MD 6 CD 6 B D))

;Para move un misionero es necesario EXISTAN MISIONEROS,
; el numero de misioneros a la izquierda sea mayor que a la derecha
;El barco este a la izquierda
(defrule moverMD_1
(estado MI ?MI CI ?CI MD ?MD CD ?CD B ?B)
(test(and(< ?CI ?MI) (eq ?B I) (< ?CD (+ 1 ?MD)) (> ?MI 0)))
=>
(assert(estado MI (- ?MI 1) CI ?CI MD (+ 1 ?MD) CD ?CD B D))
)

(defrule moverCD_1
(estado MI ?MI CI ?CI MD ?MD CD ?CD B ?B)
(test(or(and(eq ?B I) (> ?MD ?CD)) (= ?MD 0)))
(test(> ?CI 0))
=>
(assert(estado MI  ?MI CI (- ?CI 1) MD ?MD CD (+ 1 ?CD) B D))
)

(defrule moverMD_2
(estado MI ?MI CI ?CI MD ?MD CD ?CD B ?B)
(test (and(>=(- ?MI 2) ?CI) (>= ?MI 2) (eq ?B I)))
=>
(assert(estado MI (- ?MI 2) CI ?CI MD (+ 2 ?MD) CD ?CD B D))
)
(defrule moverCD_2
(estado MI ?MI CI ?CI MD ?MD CD ?CD B ?B)
(test(or(and(eq ?B I) (> ?MD (+ 2 ?CD ))) (= ?MD 0)))
(test(>= ?CI 2))
=>
(assert(estado MI  ?MI CI (- ?CI 2) MD ?MD CD (+ 2 ?CD) B D))
)

(defrule moverMI_1
(estado MI ?MI CI ?CI MD ?MD CD ?CD B ?B)
(test(and(< ?CD ?MD) (eq ?B D) (> ?MD 0)))
=>
(assert(estado MI (+ ?MI 1) CI ?CI MD (- ?MD 1 ) CD ?CD B I))
)
(defrule moverCI_1
(estado MI ?MI CI ?CI MD ?MD CD ?CD B ?B)
(test(or(and(eq ?B D) (> ?MI ?CI)) (= ?MI 0)))
;(test(> ?CD 0))
=>
(assert(estado MI  ?MI CI (+ ?CI 1) MD ?MD CD (- ?CD 1 ) B I))
)

(defrule moverMI_2
(estado MI ?MI CI ?CI MD ?MD CD ?CD B ?B)
(test (and(>=(- ?MD 2) ?CD) (>= ?MD 2)(eq ?B D)))
=>
(assert(estado MI (+ ?MI 2) CI ?CI MD (- ?MD 2) CD ?CD B I))
)
(defrule moverCI_2
(estado MI ?MI CI ?CI MD ?MD CD ?CD B ?B)
(test(or(and(eq ?B D) (>= ?MI (+ 2 ?CI ))) (= ?MI 0)))
(test(>= ?CD 2))
=>
(assert(estado MI  ?MI CI (+ ?CI 2) MD ?MD CD (- ?CD 2) B D))
)

(defrule meta
(declare (salience 10))
(estado $?x)
(meta $?p)
(test(eq $?x $?p))
=>
(exit 0)

) 



