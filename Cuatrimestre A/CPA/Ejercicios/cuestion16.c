#include <stdio.h>
#include<omp.h>
double fun( int n, double a[], double b[] )
{
    int i,ac,bc;
    double asuma,bsuma,cota;
    asuma = 0; bsuma = 0;
    #pragma omp parallel {
    #pragma omp parallel for reduction(+:asuma) nowait
    for (i=0; i<n; i++)
        asuma += a[i];
    #pragma omp  parallel for reduction(+:bsuma)
    for (i=0; i<n; i++)
        bsuma += b[i];
    }
    cota = (asuma + bsuma) / 2.0 / n;
    ac = 0; bc = 0;
    #pragma omp parallel for reduction(+:ac,bc)
    for (i=0; i<n; i++) {
        if (a[i]>cota) ac++;
        if (b[i]>cota) bc++;
    }
    
return cota/(ac+bc);
}
#define EPS 1e-16
#define DIMN 128
int fun(double a[DIMN][DIMN], double b[], double x[], int n, int nMax)
{
    int i, p, j;
    double err=100, aux[DIMN];
    for (i=0;i<n;i++)
        aux[i]=0.0;
    for (p=0;p<nMax && err>EPS;p++) {
        err=0.0;
        #pragma parallel for reduction(+:err) private(j)
        for (i=0;i<n;i++) {
            x[i]=b[i];
            for (j=0;j<i;j++)
                x[i]-=a[i][j]*aux[j];
            for (j=i+1;j<n;j++)
                x[i]-=a[i][j]*aux[j];
            x[i]/=a[i][i];
            err+=fabs(x[i]-aux[i]);
    }
    for (i=0;i<n;i++)
    aux[i]=x[i];
    }
    return p<nMax;
}