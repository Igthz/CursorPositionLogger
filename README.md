# CursorPositionLogger

O CursorPositionLogger é um aplicativo em C# que registra a posição atual do cursor e captura screenshots da tela com destaque no cursor. Essa funcionalidade pode ser incorporada em outras aplicações para obter informações sobre a localização do cursor e capturar screenshots com facilidade.

## Funcionalidades

- Registra a posição atual do cursor em coordenadas X e Y.
- Captura screenshots da tela com destaque no cursor.
- Salva as screenshots em formato PNG.
- Possibilita o registro das informações em um arquivo de log.

## Como Usar

1. faça o download do código-fonte.
2. Abra o projeto em um ambiente de desenvolvimento C# (por exemplo, Visual Studio).
3. Compile e execute o projeto.
4. O aplicativo exibirá continuamente a posição do cursor e tirará uma screenshot da tela até que a tecla Enter seja pressionada.
5. As screenshots serão salvas no diretório do projeto.
6. As informações da posição do cursor e o caminho da screenshot serão registrados no arquivo 

## Como utilizar em outras aplicações

1. Adicione o projeto "CursorPositionLogger" como uma dependência no seu projeto.
2. Importe o namespace `CursorPositionLogger` no(s) arquivo(s) do seu projeto.
3. Utilize a classe `CursorPositionTracker` para obter a posição do cursor e capturar screenshots.

## Requisitos do Sistema

- .NET Core SDK (ou Visual Studio com suporte a .NET Core).

## Preview

![image](https://github.com/Igthz/CursorPositionLogger/assets/83485103/4b75a9fe-95e4-4a9f-aa33-ea58592c34fd)


