- Estamos utilizando uma base de dados que fica em memória, logo o primeiro passo é fazer uma carga inicial na minha base de dados.

 http://localhost:59009/api/toggler (POST)

(Header)
User-Agent: Fiddler
Host: localhost:59009
Content-Length: 35
Content-Type: application/json;

(Request Body)

[
{
"id":1,
"NameButton":"isButtonBlue",
"Allowed":"",
"Restricted":"Service ABC",
"IsOn":true
},

{
"id":2,
"NameButton":"isButtonGreen",
"Allowed":"Service ABC",
"Restricted":"",
"IsOn":true
},

{
"id":3,
"NameButton":"isButtonRed",
"Allowed":"",
"Restricted":"Service ABC",
"IsOn":true
}
]

-  Conforme o comportameno dos interruptores as alterações de permissão de acesso ao serviço irão se modificando.

 
