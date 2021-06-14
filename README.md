![alt text](https://raw.githubusercontent.com/h4rdrew/TrocaIP/main/trocaip.png)

# O que faz?

O TrocaIP é um programa que altera o IP em especifico de acordo com a Máscara de SubRede padrão.
Caso o IP escolhido já exista na rede ele detecta via ping e retorna para o usuário sem alteração.

Se não existir conflitos para o IP escolhido ele altera e pergunta se voê deseja manter as configurações ou não. 
Se clicar em não, ele automaticamente configura o IP para automático (DHCP).

Ele tem countdown de 15 segundos para escolha, caso o contador chegue a 0, ele automaticamente configura o IP para automático (DHCP).

# O que falta?

configurar o DNS abaixo sempre para o IP em especifico, mesmo que o usuário clique em "Não manter as configurações":

* DNS Primário: 8.8.8.8
* DNS Secundário: 8.8.4.4
