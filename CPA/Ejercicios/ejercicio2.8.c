double funcion(int n, double u[], double v[], double w[], double z[])
{
int i;
double sv,sw,res;
#pragma omp parallel private(i)
{
    #pragma omp sections
    {
        #pragma omp section
        calcula_v(n,v); /* tarea 1 */
        #pragma omp section
        calcula_w(n,w); /* tarea 2 */
        #pragma omp section
        calcula_z(n,z); /* tarea 3 */
    }
    #pragma omp sections
    {   
        #pragma omp section
        calcula_u(n,u,v,w,z); /* tarea 4 */
        #pragma omp section 
        {
        sv = 0;
        for (i=0; i<n; i++) sv = sv + v[i]; /* tarea 5 */
        }
        #pragma omp section
        {
        sw = 0;
        for (i=0; i<n; i++) sw = sw + w[i]; /* tarea 6 */
        }
    }
    #pragma omp single
    {
        res = sv+sw;
        for (i=0; i<n; i++) u[i] = res*u[i]; /* tarea 7 */
    }
}
return res;
}