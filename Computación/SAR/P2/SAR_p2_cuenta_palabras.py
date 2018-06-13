#! -*- encoding: utf8 -*-
"""
Alumno: Marcos Esteve Casademunt
Alumno: Jose Gómez Gadea
"""
from operator import itemgetter
import re
import sys

clean_re = re.compile('\W+')
def calcular_bigramas(oracion):
    """
    Calcula una lista de bigramas

    :param oracion: Recibe una lista de palabras(oración) o una palabra,
    Si es una oración calcula los bigramas a partir de pares de palabras.
    si es una palabra calcula los bigramas a partir de pares de letras.
    :return listaBigramas: Devuelve una lista de bigramas
    """
    listaBigramas = []
    for i in range(0,len(oracion)):
            if(i != len(oracion)-1):
                if type(oracion) is list:
                    bigram = oracion[i]+" "+oracion[i+1]
                else:
                    bigram =oracion[i]+""+oracion[i+1]
                listaBigramas.append(bigram)
    return listaBigramas
def clean_text(text):
    """
    :param text: recibe el texto a limpiar.
    :return: el texto limpio de caracteres extraños y repeticiones
    """
    return clean_re.sub(' ', text)
def AppendSimbols(word,d):
    """
    Dada una palabra añade todas sus letras a un diccionario
    contabilizando la aparición de cada una las letras
    :param word: palabra a añadir.
    :param d: diccionario al que se añadirá las letras de word
    """
    for letra in word:
        countLetra = d.get(letra)
        if countLetra is None:
            d[letra] = 1
        else:
            d[letra] = countLetra +1

def AppendWords(word,d):
    """
    Dada una palabra la añade a un diccionario contabilizando el número de ocurrencias.
    :param word: palabra a añadir.
    :param d: diccionario al que se añadirá la word
    """
    count = d.get(word)
    if count is None:
        d[word] = 1
    else:
        d[word] = count +1
def printNormal(countLines =0,countWords = 0,countSimbols =0,WordsDictionary ={},SimbolsDictionary={},remove_stopwords=False):
    """
    Imprime los valores estadísticos por consola
    """
    print("Lines: %d" %countLines)
    if not remove_stopwords:
        print("Number words (with stopwords): %d" %countWords)
    else:
        print("Number words (without stopwords): %d" %countWords)
    print("Vocabulary size: %d" %len(WordsDictionary))
    print("Number of symbols: %d" %countSimbols)
    print("Number of different symbols: %d" %len(SimbolsDictionary))
    print("Words (alphabetical order):")
    printDictionaryAlphabetical(WordsDictionary)
    print("Words (by frequency):")
    printDictionaryFrequency(WordsDictionary)
    print("Symbols (alphabetical order):")
    printDictionaryAlphabetical(SimbolsDictionary)
    print("Symbols (by frequency):")
    printDictionaryFrequency(SimbolsDictionary)

def printExtra(WordsExtras,SimbolsExtra):
    """
    Imprime los valores estadísticos de la ampliación propuesta por consola
    """
    print("Words pairs (alphabetical order):")
    printDictionaryAlphabetical(WordsExtras)
    print("Words pairs (by frequency):")
    printDictionaryFrequency(WordsExtras)
    print("Symbols pairs (alphabetical order):")
    printDictionaryAlphabetical(SimbolsExtra)
    print("Symbols pairs (by frequency):")
    printDictionaryFrequency(SimbolsExtra)

def printDictionaryFrequency(d):
    """
    Imprime un diccionario segun su frecuencia (ordenados por valores)
    """
    for key, value in sorted(sorted(d.items()), key=itemgetter(1), reverse=True):
        print("\t %s \t %d" %(key, value))
def printDictionaryAlphabetical(d):
    """
    Imprime un diccionario ordenado alfabéticamente por sus claves.
    """
    for k in sorted(d.keys()):
        print("\t %s \t %d" %(k,d[k]))
def text_statistics(filename, to_lower=False, remove_stopwords=False,extra =False):
    countLines = 0
    countWords = 0
    countSimbols = 0
    WordsDictionary = {}
    SimbolsDictionary = {}
    SimbolsExtra ={}
    WordsExtra = {}
    #abrimos el fichero a leer y el fichero de stopWords
    readFile= open(filename,"r")
    stopWordsFile = open("stopwords_en.txt","r")
    stopWordsList = stopWordsFile.read().splitlines()
    for lane in readFile:
        lineaLimpia = clean_text(lane) #Primero limpio la linea de símbolos...
        if to_lower: #En caso de querer convertir a minúsculas...
            lineaLimpia = lineaLimpia.lower()
        if lineaLimpia != "":
            countLines+=1 #incrementamos el contador de lineas leídas.
            for word in lineaLimpia.split(): #Por cada palabra:
                if remove_stopwords: #si quiero eliminar las stopWords...
                    if word not in stopWordsList:
                        AppendWords(word,WordsDictionary)
                        AppendSimbols(word,SimbolsDictionary)
                else:
                    AppendWords(word,WordsDictionary)
                    AppendSimbols(word,SimbolsDictionary)
    #AMPLIACIÓN
    if extra:
        listaProcesada = []
        readFile.seek(0,0)
        FileText = readFile.read().splitlines()
        #Añadimos las palabras $ al principio y al final de cada frase
        for frase in FileText:
            listaProcesada.append("$ "+clean_text(frase).strip()+" $")
        for line in listaProcesada:
            oracion = line.split()
            listaBigramas = calcular_bigramas(oracion)
            for word in listaBigramas:
                if to_lower:
                    word = word.lower()
                if remove_stopwords:
                    if word not in stopWordsFile:
                        AppendWords(word,WordsExtra)
                else:
                    AppendWords(word,WordsExtra)
        #Bigramas para simbolos de una palabra
        for frase in FileText:
            frase = clean_text(frase.strip())
            for word in frase.split():
                listaBigramas =calcular_bigramas(word)
                for Bigram in listaBigramas:
                    if to_lower:
                        Bigram = Bigram.lower()
                    AppendWords(Bigram,SimbolsExtra)

    for key in WordsDictionary:
        countWords+=WordsDictionary.get(key)
    for key in SimbolsDictionary:
        countSimbols+=SimbolsDictionary.get(key)
    printNormal(countLines,countWords,countSimbols,WordsDictionary,SimbolsDictionary,remove_stopwords)
    if extra:
        printExtra(WordsExtra,SimbolsExtra)
def syntax():
    print ("\n%s filename.txt [to_lower?[remove_stopwords?[extra?]]\n" % sys.argv[0])
    sys.exit()

if __name__ == "__main__":
    if len(sys.argv) < 2:
        syntax()
    name = sys.argv[1]
    lower = False
    stop = False
    extra = False
    if len(sys.argv) > 2:
        lower = (sys.argv[2] in ('1', 'True', 'yes'))
        if len(sys.argv) > 3:
            stop = (sys.argv[3] in ('1', 'True', 'yes'))
            if len(sys.argv) >4 and sys.argv[4] == "extra":
                print("Modo extra activado...")
                extra = True
    text_statistics(name, to_lower=lower, remove_stopwords=stop,extra=extra)
