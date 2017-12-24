function [w,E,k]=perceptron(data,b,a,K,iw)
  %w matriz de pesos E, numero de errores, k numero de iteraciones realizadas
  [N,L]=size(data); %filas N, columnas L
  D=L-1; %columnas que no son clases
  labs=unique(data(:,L)); %vector clases unicas
  C=numel(labs); %numero total de clases
  if (nargin<5) w=zeros(D+1,C); %matriz de pesos inicial 
  else w=iw; end
  if (nargin<4) K=200; end; %numero maximo de iteraciones
  if (nargin<3) a=1.0; end;
  if (nargin<2) b=0.1; end;
  for k=1:K
    E=0;
    for n=1:N % tantas veces como filas
      xn=[1 data(n,1:D)]'; %vector normalizado fila n de los datos hasta D (Columna - clase)
      cn=find(labs==data(n,L)); % buscamos la clase a la que pertenece
      er=0;
      g=w(:,cn)'*xn; %calculamos la funcion g
      for c=1:C; %para toda clase
      if (c!=cn && w(:,c)'*xn+b>g) % comprobamos que la funcion de evaluacion +b sea mayor que g
	      w(:,c)=w(:,c)-a*xn; er=1; end; end %si eso ocurre actualizamos la matriz de pesos y flag error true
      if (er) %si error actualizamos la matriz de pesos
	      w(:,cn)=w(:,cn)+a*xn; E=E+1; end; end
    if (E==0) break; end; end
endfunction
