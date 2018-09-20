#include <stdio.h>
#include <stdlib.h>
#include<locale.h>
#include <conio.h>

int tamanho = 0;
int somaMenorCaminho(int **matriz);
int menorValorLinha(int *linha);
int alocaMatriz();

main()
{
    setlocale(LC_ALL,"portuguese");

    printf("Informe o Tamanho da Pirâmide: ");
    scanf("%d", &tamanho);

    int **matriz = alocaMatriz();
    int i, j;

    system("cls");

    for(i = 0; i < tamanho; i++)
    {
        printf("==================================================================\n");
        printf("===========   Informe os valores do topo para base    ===========\n");
        printf("==================================================================\n\n\n\n\n\n");

        for(j = 0; j < i + 1; j++)
        {
            printf("Informe o valor(es) do %dº nível é: ", i + 1);
            scanf("%d", &matriz[i][j]);
        }
        system("cls");
    }

    printf("Resultado do menor caminho da soma: %d \n\n\n", somaMenorCaminho(matriz));
    somaMenorCaminho(matriz);
    printf("==================== Autor ==================\n");

    printf("**********************************************\n");
    printf("************ Hugo Fernandes Vieira ***********\n");
    printf("**********************************************\n");

    system("pause");
    return 0;
}

int alocaMatriz()
{
    int i, j;
    int **Matriz = (int**)malloc(tamanho * sizeof(int*));

    for(i = 0; i < tamanho; i++)
    {
        Matriz[i] = (int*) malloc(tamanho * sizeof(int));
        for(j = 0; j < tamanho; j++)
        {
            Matriz[i][j] = -1;
        }
    }
    return Matriz;
}

int somaMenorCaminho(int **matriz)
{
    int i = 0, valor = 0;
    for(i; i < tamanho; i++)
    {
        valor += menorValorLinha(matriz[i]);
    }
    return valor;
}

int menorValorLinha(int *linha)
{
    int i = 0, valor = 0;
    valor = linha[0];
    for(i; i < tamanho; i++)
    {
        if(valor > linha[i] && linha[i] != -1)
        {
            valor = linha[i];
        }
    }
    return valor;
}
