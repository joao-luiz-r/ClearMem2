# ClearMem

## Utilitário residente para liberar memória não usada por aplicativos em execução

### Esta versão foi desenvolvida em NET 6, para substituir uma versão inicial desenvolvida em Delphi

**Requisitos**
 - Ter um arquivo de configuração onde possa ser configurado o tempo em segundos entre as checagens;
 - O programa deve ficar residente na Tray e ter uma opção de "Fechar"
 - De acordo com o tempo configurado, o utilitário irá varrer todos os processos em execução e liberar a memória não utilizada pelos mesmos.

## Instruções para execução
Para executar o sistema, rodar o executável "CleaqrMem.exe" da pasta ClearMem\src\ClearMem\bin\Release\net6.0\publish

