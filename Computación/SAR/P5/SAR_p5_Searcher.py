#!/usr/bin/env python

from whoosh.index import open_dir
from whoosh.qparser import QueryParser
from whoosh.query import *

ix = open_dir("index_dir")
with ix.searcher() as searcher:
    # Poner while True si queremos introducir el input por el terminal.
    while False:
        text = input("Dime:")
        if len(text) == 0:
            break
        query = QueryParser("content", ix.schema).parse(text)
        results = searcher.search(query)
#        print(dir(results))
#        print(results.docs)
        for r in results:
            # Devuelve el ID global y la posición de la noticia en el documento.
            print("ID global:",r["doc"]+".","Número de noticia:",r["num_noticia"])
            # Si hay menos de 4 ficheros, se imprime la noticia entera.
            if len(results) < 4:
                f = open("./enero/"+r["doc"], mode='r')
                f = str(f.read()).split("<DOC>")
                print(f[int(r["num_noticia"])])

# Documentos que contengan el texto "valencia"
with ix.searcher() as searcher:
    query = QueryParser("content", ix.schema).parse("valencia")
    results = searcher.search(query)
    for r in results:
        print(r)
    print(str(len(results))+" documentos.")

# Documentos que contengan el texto "valencia" y no aparezca "Salenko"
with ix.searcher() as searcher:
    query1 = And([Term("content","valencia")])
    query2 = And([Term("content","salenko")])
    results = searcher.search(query1-query2)
    for r in results:
        print(r)
    print(str(len(results))+" documentos.")

# Documentos que contengan el texto "futbol"
with ix.searcher() as searcher:
    query = QueryParser("content", ix.schema).parse("futbol")
    results = searcher.search(query)
    for r in results:
        print(r)
    print(str(len(results))+" documentos.")

# Documentos que contengan el texto "Los Angeles" y "Aeroflot"
with ix.searcher() as searcher:
    query = And([Term("content","angeles"),Term("content","aeroflot")])
    results = searcher.search(query)
    for r in results:
        print(r)
    print(str(len(results))+" documentos.")

'''
2.6.
Al hacer la consulta de buscar una noticia que contenga los términos
"Los Angeles" y "Aeroflot", el resultado obtenido es de 0 documentos.
Esto se debe a que aunque estos dos términos aparecen juntos en varios
documentos, no aparecen juntos nunca en la misma noticia.
El resto de resultados obtenidos son mayores (542, 531 y 1692 documentos
respectivamente para los tres primeros apartados del ejercicio 1.3).
'''
