import sys
import pickle
import re
clean_re = re.compile('\W+')
split_chars = ".",";","!","?"
def preproceso(input_f):
    listaPreprocesada=[]
    listaNPreprocesada = input_f.read().split("\n")
    for frase in listaNPreprocesada:
        for split in split_chars:
            frase = frase.replace(split,".")
        listaPreprocesada+=frase.split(".")
    for item in listaPreprocesada:
        if item == "":
            listaPreprocesada.remove(item)
    return listaPreprocesada

def AppendSeconDictionary(secondDictionary,secondWord):
    count = secondDictionary.get(secondWord)
    if count is None:
        secondDictionary[secondWord] = 1
    else:
        secondDictionary[secondWord] = count+1
def AppendDictionary(termsDictionary, word, secondWord):
    """
    Añade al diccionario de terminos la palabra word incluyendo cuantas veces se repite
    Añade al diccionario secundario la siguiente palabra(secondword)
    incluyendo cuantas veces se repite
    :param termsDictionary: Diccionario de términos.
    :param word: Palabra principal a añadir al diccionario de términos.
    :param secondWord: palabra secundaria para añadir al diccionario secundario de términos
    """
    value = termsDictionary.get(word)
    if value is None:
        termsDictionary[word] = [1,{}]
        AppendSeconDictionary(termsDictionary.get(word)[1],secondWord)
    else:
        value[0]+=1
        AppendSeconDictionary(value[1],secondWord)

def clean_text(text):
    """
    :param text: recibe el texto a limpiar.
    :return: el texto limpio de caracteres extraños y repeticiones
    """
    return clean_re.sub(' ', text)
def saveObject(object,outputFile):
    """
    Guarda el objeto en el fichero
    :param object: objeto a guardar
    :param outputFile: Fichero en el que se guardará el objeto
    """
    with open(outputFile,"wb") as fh:
        pickle.dump(object,fh)
def monkeyIndexer(input_file,outputFile):
    termsDictionary ={}
    input_f = open(input_file,"r")
    listPreprocesada = preproceso(input_f)
    for frase in listPreprocesada:
        frase = frase.lower()
        palabras = frase.split(" ")
        palabras.insert(len(palabras),"$")
        palabras.insert(0,"$")
        for i in range(0,len(palabras)):
            if len(palabras)-1 != i:
                primaryWord = clean_text(palabras[i])
                secondaryWord = clean_text(palabras[i+1])
                if palabras[i]== "$":
                    primaryWord = "$"
                if palabras[i+1] =="$":
                    secondaryWord = "$"
                AppendDictionary(termsDictionary,primaryWord.rstrip(),secondaryWord.rstrip())
    saveObject(termsDictionary,outputFile)
    print("Indice generado y guardado en %s" %(outputFile))
def monkeyIndexerPro(input_file,outputFile):
    """
    Indexer por trigramas, guarda en un fichero un objeto con el resultado del diccionario
    """
    termsDictionary ={}
    input_f = open(input_file,"r")
    listPreprocesada = preproceso(input_f)
    for frase in listPreprocesada:
        frase = frase.lower()
        palabras = frase.split(" ")
        palabras.insert(len(palabras),"$")
        palabras.insert(0,"$")
        palabras.insert(1,"$")
        for i in range(0,len(palabras)):
            if i < len(palabras)-2:
                primaryWord = ""
                secondaryWord = ""
                if palabras[i] != "$" and palabras[i+1] != "$":
                    primaryWord = clean_text(palabras[i]+" "+ palabras[i+1])
                if palabras[i] == "$" and palabras[i+1] == "$":
                    primaryWord = "$ $"
                if palabras[i] == "$" and not palabras[i+1] == "$":
                    primaryWord = "$ "+clean_text(palabras[i+1]).strip()
                if palabras[i+1] == "$" and not palabras[i+2] == "$":
                    secondaryWord = "$ "+ clean_text(palabras[i+2]).strip()
                if palabras[i+1] != "$" and palabras[i+2] == "$":
                    secondaryWord = clean_text(palabras[i+1]).strip()+ " $"
                if palabras[i+1] != "$" and palabras[i+2] != "$":
                    secondaryWord = clean_text(palabras[i+1]+" "+palabras[i+2])
                AppendDictionary(termsDictionary,primaryWord.rstrip(),secondaryWord.rstrip())
    print(termsDictionary)
    saveObject(termsDictionary,outputFile)
    print("Indice generado y guardado en %s" %(outputFile))
def sintax():
    print("python SAR_p3_mokey_indexer fichero_entrada fichero_salida")
if __name__ == '__main__':
    if len(sys.argv) < 3:
        sintax()
        exit()
    if len(sys.argv) >3:
        monkeyIndexerPro(sys.argv[1],sys.argv[2])
    else:
        monkeyIndexer(sys.argv[1],sys.argv[2])
