#!/usr/bin/env python
#! -*- encoding: utf8 -*-

"""
1.- Pig Latin

Nombre Alumno: Marcos Esteve Casademunt
Nombre Alumno: Jose Gómez Gadea

"""

import sys

vocales = "a","e","i","o","u","y"
signos_puntuacion =  ",",";",".","?","!"

def piglatin_word(word):
    """
    Esta función recibe una palabra en inglés y la traduce a Pig Latin

    :param word: la palabra que se debe pasar a Pig Latin
    :return: la palabra traducida
    """
    #si no es una letra no traduzco
    if word[0].isdigit():
        return word
    isUpperCase = False
    CapitalLetterisUpperCase = False
    #compruebo que la longitud de la palabra sea mayor que uno...
    if len(word) > 1:
        #supongo que si la primera letra y la segunda están en mayusculas la palabra estará en mayusculas
        if word[0].isupper() and not word[1].isupper():
            CapitalLetterisUpperCase = True
        elif word[0].isupper() and word[1].isupper():
            isUpperCase = True
    else:
        CapitalLetterisUpperCase = word[0].isupper()
    word = word.lower()
    #si la primera letra es una vocal añado yay al final y sus signos de puntuación (si los tiene :-))
    if word[0] in vocales:
        if word[-1] in signos_puntuacion:
            word = word[0:len(word)-1] + "yay"+word[-1]
        else:
            word = word + "yay"
    else: #si la primera letra es una consonante...
        indice = 0
        #busco la primera vocal...
        for letra in word:
            if letra not in vocales:
                indice+=1
            else:
                break
        #genero la traducción añadiendo ay y los signos de puntuación (si los hay -_- )
        if word[-1] in signos_puntuacion:
            word = word[indice : len(word)-1]+word[0 : indice]+"ay"+word[-1]
        else:
            word = word[indice : len(word)]+word[0 : indice]+"ay"
    #si la palabra era mayúsculas la transformo a mayúsculas
    if isUpperCase:
        word = word.upper()
    #si la primera letra era mayúscula
    elif CapitalLetterisUpperCase:
        word = word[0].upper()+word[1:]
    return word


def piglatin_sentence(sentence):
    """
    Esta función recibe una frase en inglés i la traduce a Pig Latin

    :param sentence: la frase que se debe pasar a Pig Latin
    :return: la frase traducida
    """
    sentence_array = sentence.split()
    result = ""
    for word in sentence_array:
        result+=piglatin_word(word)+ " "
    result = result[0:len(result)-1]
    return  result


if __name__ == "__main__":
    if len(sys.argv) > 1 and  sys.argv[1] != "-f":
        print(piglatin_sentence(sys.argv[1]))
    elif len(sys.argv) > 1 and sys.argv[1] == "-f":
        filename = sys.argv[2]
        if not filename.endswith(".txt"):
            print("La extensión del fichero no es la correcta")
        else:
            finput = open(filename,"r")
            foutput = open(filename+"_pigLatin.txt","w")
            for line in finput:
                print("Traduciendo... "+ line)
                foutput.write(piglatin_sentence(line)+"\n")
            finput.close()
            foutput.close()

    else:
        while True:
            sentence = input("English: ")
            #si la secuencia introducida es la cadena vacia finalizo.
            if sentence is "":
                break
            print("PIG LATIN: "+piglatin_sentence(sentence))
            pass
