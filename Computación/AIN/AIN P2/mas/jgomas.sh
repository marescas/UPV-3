#!/bin/sh

java -classpath "lib/jade.jar:lib/jadeTools.jar:lib/Base64.jar:lib/http.jar:lib/iiop.jar:lib/beangenerator.jar:lib/jgomas.jar:lib/jason.jar:lib/JasonJGomas.jar:classes:." jade.Boot -gui -host 127.0.0.1 "Manager:es.upv.dsic.gti_ia.jgomas.CManager(6,map_04,125,10)"

delay 5

java -classpath "lib/jade.jar:lib/jadeTools.jar:lib/Base64.jar:lib/http.jar:lib/iiop.jar:lib/beangenerator.jar:lib/jgomas.jar:lib/jason.jar:lib/JasonJGomas.jar:classes:." jade.Boot -container -host localhost "T1:es.upv.dsic.gti_ia.JasonJGomas.BasicTroopJasonArch(jasonAgent_AXIS.asl);T2:es.upv.dsic.gti_ia.JasonJGomas.BasicTroopJasonArch(jasonAgent_AXIS.asl);T3:es.upv.dsic.gti_ia.JasonJGomas.BasicTroopJasonArch(jasonAgent_AXIS_FIELDOPS.asl);A1:es.upv.dsic.gti_ia.JasonJGomas.BasicTroopJasonArch(jasonAgent_ALLIED_MEDIC.asl);A2:es.upv.dsic.gti_ia.JasonJGomas.BasicTroopJasonArch(jasonAgent_ALLIED.asl);A3:es.upv.dsic.gti_ia.JasonJGomas.BasicTroopJasonArch(jasonAgent_ALLIED_MEDIC.asl)"
