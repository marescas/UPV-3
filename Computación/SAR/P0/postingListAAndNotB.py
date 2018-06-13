def aAndNotB(a,b):
    """
    Algorítmo A and not B
    :param a: posting list A (ordenada)
    :param b: posting list B (ordenada)
    :returns: devuelve una lista con la operación a and not B sobre las listas.
    """
    returnData = []
    i = 0
    j = 0
    while i < len(a) and j < len(b):
        if a[i] == b[j]:
            i+=1
            j+=1
        elif a[i]> b[j]:
            j+=1
        else:
            returnData.append(a[i])
            i+=1
    if i<len(a):
        returnData += a[i:]
    return  returnData

if __name__ == '__main__':
    postingA = [2,4,8,16,32,64,128]
    postingB = [1,2,3,5,8,13,21,34]
    print(aAndNotB(postingA,postingB))
