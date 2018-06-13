#!/usr/bin/env python

import os

from whoosh.index import create_in
from whoosh.fields import Schema, ID, TEXT
from whoosh.analysis import LowercaseFilter, RegexTokenizer, StopFilter

# Analizadores que utilizará el schema
my_analizer = RegexTokenizer() | LowercaseFilter() | StopFilter(lang="es")
# Esquema en el que se guarda el título e ID
schema = Schema(title=TEXT(stored=True),
                path=ID(stored=True), num_noticia=TEXT(stored=True),
                doc=TEXT(stored=True),content=TEXT)#(analyzer=my_analizer))
# Nombre del directorio donde se guardará el índice
idir = "index_dir"
# Creación del directorio donde se guarda el índice
if not os.path.exists(idir):
    os.mkdir(idir)
ix = create_in(idir, schema)

# El writer añadirá los índices
writer = ix.writer()

# Ficheros a añadir
nomF = os.listdir("./enero")
for filename in nomF:
    f = open("./enero/"+filename, mode='r')
    f = str(f.read()).split("<DOC>")
    for numNoticia in range(1,len(f)):
        writer.add_document(title=filename+"-"+str(numNoticia),
                            doc=filename,num_noticia=str(numNoticia),
                            path="./enero/"+filename, content=f[numNoticia])
    print("File indexed: "+filename)
print("Saving index...")
writer.commit()
print("Index saved.")

'''
1.2.
El índice ocupa 40'4 MB en caso de no utilizar ningún analizador, dado
que realmente sí que está utilizando de forma predeterminada los tres
que vamos a utilizar a continuación.
En caso de utilizar el analizador RegexTokenizer(), el índice ocupa 46'1 MB,
dado que se trata de un tokenizador que elimina los caracteres especiales
pero no las palabras.
Si utilizamos el analizador anterior junto con el LowercaseFilter(),
el indice ocupa 40'9 MB y la disminución de espacio se debe a que no
distingue a partir de ahora entre mayúsculas y minúsculas.
Si además añadimos el StopFilter() para el idioma español, conseguimos
reducir el tamaño del índice hasta pasar a ocupar 40'4 MB, dado que estamos
eliminando todas las stopwords.
'''
