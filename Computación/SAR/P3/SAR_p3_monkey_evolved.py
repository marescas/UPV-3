import pickle
import sys
import random
def listToRandom(lista_keys, diccionario):
    listToRand = []
    for k in lista_keys:
        for i in range(0,int(diccionario.get(k))):
            listToRand.append(k)
    return listToRand
def load_object(fileName):
    """
    Devuelve un objeto tras cargar el fichero
    :param fileName: fichero a cargar
    :return: objeto
    """
    with open(fileName,"rb") as fh:
        obj = pickle.load(fh)
    return obj
def sintax():
    print("python SAR_p3_monkey_evolved nombreFichero")
def generador(fileName,numfrases,numElements=25):
    """
    Genera numfrases frases de un máximo de numElements
    :param fileName: fichero de entrada
    :param numfrases: número de frases a generar
    :param numElements: número de palabras máximas por frase
    """
    oraciones =[]
    termsDictionary = load_object(fileName)
    for i in range(0,numfrases):
        cont =0
        term = termsDictionary.get("$")
        oracion = "$"
        while cont < numElements:
            keysTerm = list(term[1].keys()) #obtengo la lista de keys
            listToRand = listToRandom(keysTerm,term[1])
            myKey = random.choice(listToRand)
            oracion+= " "+myKey
            if myKey == "$":
                break
            term = termsDictionary[myKey]
            cont+=1
        oraciones.append(oracion)
    return oraciones
def generadorPro(fileName,numfrases,numElements=25):
    """
    Genera numfrases frases de un máximo de numElements utilizando trigramas
    :param fileName: fichero de entrada
    :param numfrases: número de frases a generar
    :param numElements: número de palabras máximas por frase
    """
    oraciones =[]
    termsDictionary = load_object(fileName)
    print("Generando por trigramas...")
    for i in range(0,numfrases):
        cont =0
        term = termsDictionary.get("$ $")
        oracion = "$"
        while cont < numElements:
            keysTerm = list(term[1].keys()) #obtengo la lista de keys
            listToRand = listToRandom(keysTerm,term[1])
            myKey = random.choice(listToRand)
            try:
                oracion+= " "+myKey.split(" ")[1]
                if "$" == myKey.split(" ")[1]:
                    break
            except:
                oracion+= " "+ myKey
                if "$" ==myKey:
                    break

            term = termsDictionary[myKey]
            cont+=1
        oraciones.append(oracion)
    return oraciones
if __name__ == '__main__':
    if len(sys.argv) < 2:
        sintax()
        exit()
    if len(sys.argv) > 2:
        oraciones = generadorPro(sys.argv[1],20,25)
    else:
        oraciones = generador(sys.argv[1],20,25)
    for oracion in oraciones:
        print(oracion)
