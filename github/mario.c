#include <stdio.h>
#include <cs50.h>


//1.問height <8 跑do while迴圈 
int main(void)
{
    int n;
    do
    {
        n = get_int("height: ");
    }
    while (n < 1 || n>8);
    
    int i = 0, j = 0;
    for (i = 1; i <= n; i++)
    {
        for (j = 1; j <= n - i; j++)
        {
        printf(" ");
        }
        for (j = 1; j <= i; j++) 
        {
        printf("#");
        }
        printf("\n");
    }
}
