;hechos iniciales
(deffacts datos
	(jug name jugX capacity 4 contents 0)
	(jug name jugY capacity 3 contents 0)
	(jug name jugX colours red blue)
	(jug name jugY colours))
;reglas	
(defrule fill-jug
	?f <- (jug name ?nombre capacity ?cap contents ?cont)
	(test (< ?cont ?cap ))
=>
	(retract ?f)
	(assert (jug name ?nombre capacity ?cap contents ?cap)))
	