def intersection(a,b):
    """
    Algorítmo de interección entre dos posting list planteado en las clases de teoría
    :param a: posting list A
    :param b: posting list B
    :returns: devuelve una lista con la interseccion de las dos listas.

    """
    returndata = []
    i = 0
    j = 0
    while i<len(a) and j < len(b):
        if a[i] == b[j]:
            returndata.append(a[i])
            i+=1
            j+=1
        elif a[i] > b[j]:
            j+=1
        else:
            i+=1
    return returndata

if __name__ == '__main__':
    listA = [2,4,8,16,32,61,128]
    listB = [1,2,3,5,8,13,21,34]
    print(intersection(listA,listB))
    intersection
