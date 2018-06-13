from operator import itemgetter
from nltk.probability import *
# Acceder al corpus en castellano cess_esp
from nltk.corpus import cess_esp
from nltk.corpus import PlaintextCorpusReader
from nltk.corpus import stopwords
from nltk.tokenize import RegexpTokenizer
from nltk.stem import SnowballStemmer
tokenizer = RegexpTokenizer(r'\w+')
def remove_stopwords(text,language="english"):
    stopwordsw = stopwords.words(language)
    result = [w for w in text if w.lower() not in stopwordsw]
    return result
# Ejercicio 1
# Mostrar el número de palabras que contiene este corpus
print("El numero de palabras en este corpus es %d" % len(cess_esp.words()))
# Mostrar el número de frases que contiene
print("El número de oraciones en este corpues es %d" % len(cess_esp.sents()))
"""
Obtener las frecuencias de aparición de los ítems que componen el primer fichero del corpus
anterior. Un ítem es un par (key, value) donde key es la palabra y value es la frecuencia de
aparición de la palabra. Visualizar los 20 más frecuentes.
"""
text= cess_esp.words(cess_esp.fileids()[0])

fdist=FreqDist(text)
print (fdist.most_common(20))
# Obtener el vocabulario del primer fichero del corpus (ordenado por frecuencia).
print("vocabulario ordenado por frecuencia")
p =[w for w,f in fdist.most_common()]
print(p)
# Obtener de forma ordenada las palabras del vocabulario de longitud mayor que 7 y
# que aparezcan más de 2 veces en el primer fichero del corpus
print("Palabras con longitud > 7 y frecuencia  > 2")
TwoTimes = [w for w in set(text) if fdist[w] >2]
resultado = [w for w in TwoTimes if len(w) >7]
print(resultado)
#Obtener la frecuencia de aparición de las palabras en el primer fichero del corpus. Además, y
#para el mismo fichero obtener la frecuencia de la palabra ‘a’.
print([f for w,f in fdist.most_common()])
print("La frecuencia  de la palabra a es %d" %fdist["a"])
#Obtener el número de palabras que sólo aparecen una vez en el primer fichero del corpus.
print("Número de palabras que aparecen solo una vez:")
print(len([w for w in set(text) if fdist[w] == 1]))
#Obtener la palabra más frecuente del primer fichero del corpus.
print("La palabra más frecuente es %s" %fdist.max())
#Cargar los ficheros de PoliformaT (“spam.txt”, “quijote.txt” y “tirantloblanc.txt” ) como un corpus propio.
corpus_root = '.'
wordlists = PlaintextCorpusReader(corpus_root, ["spam.txt","quijote.txt","tirantloblanc.txt"])
print("corpus cargado")
#Calcular el número de palabras, el número de palabras distintas y el número de frases de los tres documentos.
for i in range(0,3):
    nombre =wordlists.fileids()[i]
    npalabras =len(wordlists.words(wordlists.fileids()[i]))
    npaldistintas = len(set(wordlists.words(wordlists.fileids()[i])))
    nfrases = len(wordlists.sents(wordlists.fileids()[i]))
    print("fichero: %s num palabras: %d num palabras distintas: %d num frases %d" % (nombre,npalabras,npaldistintas,nfrases))

print("Ejercicio 2")
from nltk.corpus import brown
words = ["what","where","who","when","why"]
mydict = {}
for word in words:
    mydict[word] =[]
categoriess= brown.categories()
for word in words:
    for category in categoriess:
        frecuencia = len([w for w in brown.words(categories=category) if w ==word])
        mydict[word].append((category,frecuencia))
print(mydict)
print("Ejercicio 3")
#Cargar el documento “quijote.txt” en una única cadena
texto = " ".join( open("quijote.txt","r").read().split("\n"))
#Mostrar todos los símbolos del documento ordenados por orden alfabético.
simbolos = sorted(set(texto))
print(simbolos)
print("Simbolos eliminados")
#Eliminar del texto los símbolos
texto_filtrado = " ".join(tokenizer.tokenize(texto))
simbolos2 = sorted(set(list(texto_filtrado)))
print(simbolos2)
#Obtener el número de palabras y el número de palabras distintas del texto filtrado. Mostrar la
#10 primeras y las 10 últimas en orden alfabético
print("palabras %d palabras distintas %d" %(len(texto_filtrado.split(" ")),len(set(texto_filtrado.split(" ")))))
words =sorted(set([w for w in texto_filtrado.split(" ")]))
print(" ".join(words[0:10]))
print(" ".join(words[len(words)-10:]))
# Obtener las frecuencias de aparición de los ítems que componen el documento
# filtrado. Un ítem es un par (key, value) donde key es la palabra y value es la
# frecuencia de aparición de la palabra. Visualizar los primeros 20 ítems.
fdist = FreqDist(texto_filtrado.split(" "))
print("Frecuencia de aparición de los items en el doc filtrado")
print(fdist.most_common(20))
#Crear un nuevo documento eliminando las stopwords del texto filtrado.
fileoutput = open("quijote_sin_stop_words.txt","w")
textosalida = " ".join(remove_stopwords(texto_filtrado.split(" "),"spanish"))
fileoutput.write(textosalida)
fileoutput.close()
print("fichero guardado con nombre: quijote_sin_stop_words.txt")
texto = " ".join( open("quijote_sin_stop_words.txt","r").readlines())
# Obtener el número de palabras y el número de palabras distintas del texto sin
# stopwords. Mostrar la 10 primeras y las 10 últimas en orden alfabético
print("palabras %d palabras distintas %d" %(len(texto.split(" ")),len(set(texto.split(" ")))))
words =sorted(set([w for w in texto.split(" ")]))
print(" ".join(words[0:10]))
print(" ".join(words[len(words)-10:]))
# Obtener las frecuencias de aparición de los ítems que componen el documento sin
# stopwords. Visualizar los primeros 20 ítems.
fdist = FreqDist(texto.split(" "))
print("Frecuencia de aparición de los items en el doc sin stopwords")
print(fdist.most_common(20))
# Crear un nuevo documento sustituyendo cada palabra del texto sin stopwords por
# su raíz. Para ello se utilizará el stemmer snowball.
fileoutput = open("quijote_stem.txt","w")
stemmer  = SnowballStemmer("spanish")
textosalida = " ".join([stemmer.stem(w) for w in texto.split(" ")])

fileoutput.write(textosalida)
fileoutput.close()
print("fichero guardado con nombre: quijote_stem.txt")
texto = " ".join( open("quijote_stem.txt","r").readlines())
# Obtener el número de palabras y el número de palabras distintas del nuevo
# documento. Mostrar la 10 primeras y las 10 últimas en orden alfabético
print("palabras %d palabras distintas %d" %(len(texto.split(" ")),len(set(texto.split(" ")))))
words =sorted(set([w for w in texto.split(" ")]))
print(" ".join(words[0:10]))
print(" ".join(words[len(words)-10:]))
# Obtener las frecuencias de aparición de los ítems que componen el nuevo
# documento. Visualizar los primeros 20 ítems.
fdist = FreqDist(texto.split(" "))
print("Frecuencia de aparición de los items en el doc con stem")
print(fdist.most_common(20))
