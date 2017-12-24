(deffacts datos
(inicial W E B B W mov nul)
(meta B B E W W))
(defrule move-1-left
?f1<- (inicial $?x ?y E $?z mov ?mov)
(test(or(eq ?mov nul)(neq ?mov mov1der)))
=>
;(retract ?f1)
(assert (inicial $?x E ?y $?z mov mov1izq) )
)

(defrule move-2-left
?f1<- (inicial $?x ?w ?y E $?z mov ?mov)
(test(or(eq ?mov nul)(neq ?mov mov2der)))
=>
;(retract ?f1)
(assert (inicial $?x E ?y ?w $?z mov mov2izq) )
)

(defrule move-1-right
?f1<- (inicial $?x E ?y $?z mov ?mov)
(test(or(eq ?mov nul)(neq ?mov mov1izq)))
=>
;(retract ?f1)
(assert (inicial $?x ?y E $?z mov mov1der) )
)
(defrule move-2-right
?f1<- (inicial $?x E ?y ?w $?z mov ?mov)
(test(or(eq ?mov nul)(neq ?mov mov2izq)))
=>
;(retract ?f1)
(assert (inicial $?x ?w ?y E $?z mov mov2der) )
)
(defrule meta
(declare(salience 100))
(inicial $?x mov ?)
(meta $?z)
(test (eq $?x $?z))
=>
(printout t "conseguido!" crlf)
(halt)
)
