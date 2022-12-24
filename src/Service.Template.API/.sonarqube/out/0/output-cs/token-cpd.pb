�
oD:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Domain\Entities\JWT\Key.cs
	namespace 	
Exemplo
 
. 
Domain 
. 
Entities !
.! "
JWT" %
{		 
public

 

class

 
Key

 
{ 
[ 	
JsonProperty	 
( 
$str 
) 
] 
public

 
string

 
E

 
{

 
get

 
;

 
set

 "
;

" #
}

$ %
[ 	
JsonProperty	 
( 
$str 
) 
] 
public 
string 
N 
{ 
get 
; 
set "
;" #
}$ %
public 
string 
ClientId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
Key 
( 
) 
{ 	
} 	
public 
Key 
( 
string 
e 
, 
string #
n$ %
,% &
string' -
clientId. 6
)6 7
{ 	
E 

= 
e 
; 
N 

= 
n 
; 
ClientId 
= 
clientId 
;  
} 	
} 
} �
|D:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Domain\Entities\JWT\ResponseApiToken.cs
	namespace 	
Exemplo
 
. 
Domain 
. 
Entities !
.! "
JWT" %
{ 
public		 

class		 
ResponseApiToken		 !
{

 
public 
string 
Token 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
	Resultado 
{  !
get" %
;% &
set' *
;* +
}, -
public

 
string

 
Mensagem

 
{

  
get

! $
;

$ %
set

& )
;

) *
}

+ ,
public 
string 
Data 
{ 
get  
;  !
set" %
;% &
}' (
public 
ResponseApiToken 
(  
)  !
{ 	
} 	
public 
ResponseApiToken 
(  
string  &
token' ,
,, -
string. 4
	resultado5 >
,> ?
string@ F
mensagemG O
,O P
stringQ W
dataX \
)\ ]
{ 	
Token 
= 
token 
; 
	Resultado 
= 
	resultado !
;! "
Mensagem 
= 
mensagem 
;  
Data 
= 
data 
; 
} 	
} 
} �
pD:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Domain\Entities\JWT\User.cs
	namespace 	
Exemplo
 
. 
Domain 
. 
Entities !
.! "
JWT" %
{ 
public		 

class		 
User		 
{

 
public 
Guid 
ClientId 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
ClientSecret "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
User 
( 
) 
{ 	
} 	
public 
User 
( 
Guid 
clientId !
,! "
string# )
clientSecret* 6
)6 7
{ 	
ClientId 
= 
clientId 
;  
ClientSecret 
= 
clientSecret '
;' (
} 	
} 
} �
qD:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Domain\Entities\Navigator.cs
	namespace 	
Exemplo
 
. 
Domain 
. 
Entities !
{ 
public		 

class		 
	Navigator		 
{

 
public 
int 
RecordCount 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
int 

PageNumber 
{ 
get  #
;# $
set% (
;( )
}* +
public

 
int

 
PageSize

 
{

 
get

 !
;

! "
set

# &
;

& '
}TemplateTemplate

( )
public 
int 
	PageCount 
{ 
get "
;" #
Template$ '
;' (
}) *
public 
	Navigator 
( 
) 
{ 	
} 	
public 
	Navigator 
( 
int 
TemplateCount (
,( )
int* -

pageNumber. 8
,8 9
int: =
pageSize> F
,F G
intH K
	pageCountL U
)U V
{ 	
RecordCount 
= 
recordCount %
;% &

PageNumber 
= 

pageNumber #
;# $
PageSize 
= 
pageSize 
;  
	PageCount 
= 
	pageCount !
;! "
} 	
} 
} �!
uD:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Domain\Entities\Pessoa\Pessoa.cs
	namespace 	
Exemplo
 
. 
Domain 
. 
Entities !
.! "
Pessoa" (
{ 
[ 
Table 

(
 
$str 
) 
] 
public 

class 
Pessoa 
{		 
[

 	
Key

	 
]

 

public 
long 
Id 
{ 
get 
Template 
set !
;! "
}# $
[

Template
Required

	 
]

 
public 
string 
Nome 
{ 
get  
Template  !
set" %
;% &
}' (
public 
DateTime 
DataNascimento &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
int 
Status 
{ 
get 
;  
set! $
;$ %
}& '
public 
DateTime 
? 

DTemplateert #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
DateTime 
? 

DataUpdate #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
Pessoa 
( 
) 
{ 	
} 	
public 
Pessoa 
( 
long 
id 
) 
{ 	
Id 
= 
id 
Template 
} 	
public 
Pessoa 
( 
string 
nome !
,! "
DateTime# +
dataNascimento, :
,: ;
int< ?
status@ F
)F G
{ 	
Nome   
=   
nome   
;   
DataNascimento!! 
=!! 
dataNascimento!! +
;!!+ ,
Status"" 
="" 
status"" 
;"" 
}## 	
public%% 
Pessoa%% 
(%% 
long%% 
id%% 
,%% 
string%% %
Template%%& *
,%%* +
DateTime%%, 4
dataNascimento%%5 C
,%%C D
int%%E H
status%%I O
)%%O P
:%%Q R
this%%S W
(%%W X
id%%X Z
)%%Z [
{&& 	
Nome'' 
='' 
nome'' 
;'' 
DataNascimento(( 
=(( 
dataNascimento(( +
;((+ ,
Status)) 
=)) 
status)) 
;)) 
}** 	
public,, 
Pessoa,, 
(,, 
string,, 
nome,, !
,,,! "
DateTime,,# +
dataNascimento,,, :
,,,: ;
int,,< ?
status,,@ F
,,,F G
DateTime,,H P
?,,P Q

dataUpdate,,R \
),,\ ]
:,,^ _
this,,` d
(,,d e
nome,,e i
,,,i j
dataNascimento,,k y
,,,y z
status	,,{ �
)
,,� �
{-- 	

DataUpdate.. 
=.. 

dataUpdate.. #
;..# $
}// 	
public11 
Pessoa11 
(11 
long11 
id11 
,11 
string11 %
nome11& *
,11* +
DateTime11, 4
dataNascimento115 C
,11C D
int11E H
status11I O
,11O P
DateTime11Q Y
?11Y Z

dataInsert11[ e
,11e f
DateTime11g o
?11o p

dataUpdate11q {
)11{ |
:11} ~
this	11 �
(
11� �
id
11� �
,
11� �
nome
11� �
,
11� �
dataNascimento
11� �
,
11� �
status
11� �
)
11� �
{22 	

DataInsert33 
=33 

dataInsert33 #
;33# $

DataUpdate44 
=44 

dataUpdate44 #
;44# $
}55 	
}66 
}77 �
kD:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Domain\Enum\EAction.cs
	namespace 	
Exemplo
 
. 
Domain 
. 
Enum 
{ 
public		 

enum		 
EAction		 
{

 
INSERT 
= 
$num 
, 
UPDATE 
= 
$num 
, 
DELETE

 
=

 
$num

 
} 
} �
wD:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Domain\Enum\EDataBaseConnection.cs
	namespace 	
Exemplo
 
. 
Domain 
. 
Enum 
{ 
public		 

enum		 
EDataBaseConnection		 #
{

 

ID_DB_EXEMPLO 
= 
$num 
, 
	ID_DB_LOG 
= 
$num 
}

 
} �`
�D:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Domain\Interfaces\Repositories\Base\IRepositoryBase.cs
	namespace 	
Exemplo
 
. 
Domain 
. 

Interfaces #
.# $
Repositories$ 0
.0 1
Base1 5
{		 
public

 

	interface

 
IRepositoryBase

 $
<

$ %
TEntity

% ,
>

, -
where

. 3
TEntity

4 ;
:

< =
class

> C
{ 
Tuple 

<
 
IEnumerable 
< 
T1 
> 
, 
IEnumerable *
<* +
T2+ -
>- .
>. /
GetMultiple0 ;
<; <
T1< >
,> ?
T2@ B
>B C
(C D
stringD J
sqlK N
,N O
objectP V

parametersW a
,a b
Func

 
<

 

GridReader

 
,

 
IEnumerable

 (
<

( )
T1

) +
>

+ ,
>

, -
func1

. 3
,

3 4
Func

5 9
<

9 :

GridReader

: D
,

D E
IEnumerable

F Q
<

Q R
T2

R T
>

T U
>

U V
func2

W \
)

\ ]
;

] ^
Tuple 

<
 
IEnumerable 
< 
T1 
> 
, 
IEnumerable *
<* +
T2+ -
>- .
,. /
IEnumerable0 ;
<; <
T3< >
>> ?
>? @
GetMultipleA L
<L M
T1M O
,O P
T2Q S
,S T
T3U W
>W X
(X Y
stringY _
sql` c
,c d
objecte k

parametersl v
,v w
Func 
< 

GridReader 
, 
IEnumerable (
<( )
T1) +
>+ ,
>, -
func1. 3
,3 4
Func 
< 

GridReader 
, 
IEnumerable (
<( )
T2) +
>+ ,
>, -
func2. 3
,3 4
Func 
< 

GridReader 
, 
IEnumerable (
<( )
T3) +
>+ ,
>, -
func3. 3
)3 4
;4 5
Tuple 

<
 
IEnumerable 
< 
T1 
> 
, 
IEnumerable *
<* +
T2+ -
>- .
,. /
IEnumerable0 ;
<; <
T3< >
>> ?
,? @
IEnumerableA L
<L M
T4M O
>O P
>P Q
GetMultipleR ]
<] ^
T1^ `
,` a
T2b d
,d e
T3f h
,h i
T4j l
>l m
(m n
stringn t
sqlu x
,x y
object	z �

parameters
� �
,
� �
Func 
< 

GridReader 
, 
IEnumerable (
<( )
T1) +
>+ ,
>, -
func1. 3
,3 4
Func 
< 

GridReader 
, 
IEnumerable (
<( )
T2) +
>+ ,
>, -
func2. 3
,3 4
Func 
< 

GridReader 
, 
IEnumerable (
<( )
T3) +
>+ ,
>, -
func3. 3
,3 4
Func 
< 

GridReader 
, 
IEnumerable (
<( )
T4) +
>+ ,
>, -
func4. 3
) 	
;	 

Tuple 

<
 
IEnumerable 
< 
T1 
> 
, 
IEnumerable *
<* +
T2+ -
>- .
,. /
IEnumerable0 ;
<; <
T3< >
>> ?
,? @
IEnumerableA L
<L M
T4M O
>O P
,P Q
IEnumerableR ]
<] ^
T5^ `
>` a
>a b
GetMultiplec n
<n o
T1o q
,q r
T2s u
,u v
T3w y
,y z
T4{ }
,} ~
T5	 �
>
� �
(
� �
string
� �
sql
� �
,
� �
object
� �

parameters
� �
,
� �
Func 
< 

GridReader 
, 
IEnumerable (
<( )
T1) +
>+ ,
>, -
func1. 3
,3 4
Func 
< 

GridReader 
, 
IEnumerable (
<( )
T2) +
>+ ,
>, -
func2. 3
,3 4
Func 
< 

GridReader 
, 
IEnumerable (
<( )
T3) +
>+ ,
>, -
func3. 3
,3 4
Func 
< 

GridReader 
, 
IEnumerable (
<( )
T4) +
>+ ,
>, -
func4. 3
,3 4
Func   
<   

GridReader   
,   
IEnumerable   (
<  ( )
T5  ) +
>  + ,
>  , -
func5  . 3
)!! 	
;!!	 

Tuple## 

<##
 
IEnumerable## 
<## 
T1## 
>## 
,## 
IEnumerable## *
<##* +
T2##+ -
>##- .
,##. /
IEnumerable##0 ;
<##; <
T3##< >
>##> ?
,##? @
IEnumerable##A L
<##L M
T4##M O
>##O P
,##P Q
IEnumerable##R ]
<##] ^
T5##^ `
>##` a
,##a b
IEnumerable##c n
<##n o
T6##o q
>##q r
>##r s
GetMultiple##t 
<	## �
T1
##� �
,
##� �
T2
##� �
,
##� �
T3
##� �
,
##� �
T4
##� �
,
##� �
T5
##� �
,
##� �
T6
##� �
>
##� �
(
##� �
string
##� �
sql
##� �
,
##� �
object
##� �

parameters
##� �
,
##� �
Func$$ 
<$$ 

GridReader$$ 
,$$ 
IEnumerable$$ (
<$$( )
T1$$) +
>$$+ ,
>$$, -
func1$$. 3
,$$3 4
Func%% 
<%% 

GridReader%% 
,%% 
IEnumerable%% (
<%%( )
T2%%) +
>%%+ ,
>%%, -
func2%%. 3
,%%3 4
Func&& 
<&& 

GridReader&& 
,&& 
IEnumerable&& (
<&&( )
T3&&) +
>&&+ ,
>&&, -
func3&&. 3
,&&3 4
Func'' 
<'' 

GridReader'' 
,'' 
IEnumerable'' (
<''( )
T4'') +
>''+ ,
>'', -
func4''. 3
,''3 4
Func(( 
<(( 

GridReader(( 
,(( 
IEnumerable(( (
<((( )
T5(() +
>((+ ,
>((, -
func5((. 3
,((3 4
Func)) 
<)) 

GridReader)) 
,)) 
IEnumerable)) (
<))( )
T6))) +
>))+ ,
>)), -
func6)). 3
)** 	
;**	 

Tuple,, 

<,,
 
IEnumerable,, 
<,, 
T1,, 
>,, 
,,, 
IEnumerable,, *
<,,* +
T2,,+ -
>,,- .
,,,. /
IEnumerable,,0 ;
<,,; <
T3,,< >
>,,> ?
,,,? @
IEnumerable,,A L
<,,L M
T4,,M O
>,,O P
,,,P Q
IEnumerable,,R ]
<,,] ^
T5,,^ `
>,,` a
,,,a b
IEnumerable,,c n
<,,n o
T6,,o q
>,,q r
,,,r s
IEnumerable,,t 
<	,, �
T7
,,� �
>
,,� �
>
,,� �
GetMultiple
,,� �
<
,,� �
T1
,,� �
,
,,� �
T2
,,� �
,
,,� �
T3
,,� �
,
,,� �
T4
,,� �
,
,,� �
T5
,,� �
,
,,� �
T6
,,� �
,
,,� �
T7
,,� �
>
,,� �
(
,,� �
string
,,� �
sql
,,� �
,
,,� �
object
,,� �

parameters
,,� �
,
,,� �
Func-- 
<-- 

GridReader-- 
,-- 
IEnumerable-- (
<--( )
T1--) +
>--+ ,
>--, -
func1--. 3
,--3 4
Func.. 
<.. 

GridReader.. 
,.. 
IEnumerable.. (
<..( )
T2..) +
>..+ ,
>.., -
func2... 3
,..3 4
Func// 
<// 

GridReader// 
,// 
IEnumerable// (
<//( )
T3//) +
>//+ ,
>//, -
func3//. 3
,//3 4
Func00 
<00 

GridReader00 
,00 
IEnumerable00 (
<00( )
T400) +
>00+ ,
>00, -
func400. 3
,003 4
Func11 
<11 

GridReader11 
,11 
IEnumerable11 (
<11( )
T511) +
>11+ ,
>11, -
func511. 3
,113 4
Func22 
<22 

GridReader22 
,22 
IEnumerable22 (
<22( )
T622) +
>22+ ,
>22, -
func622. 3
,223 4
Func33 
<33 

GridReader33 
,33 
IEnumerable33 (
<33( )
T733) +
>33+ ,
>33, -
func733. 3
)44 	
;44	 

Task66 
<66 

IEnumerable66
 
<66 
TTemplate66  
>66  !
>66! "
Get66# &
Template6& '
string66' -
query66. 3
)663 4
;664 5
Task77 
<77 

IEnumerable77
 
<77 
TEntity77  
>77  !
>77! "
GetAll77# )
(77) *
)77* +
;77+ ,
Task88 
<88 

TEntity88
 
>88 
GetById88 
(88 
long88 "
id88# %
)88% &
;88& '
Task99 
<99 

bool99
 
>99 

InsertCommand99  
(99  !
string99! '
query99( -
)99- .
;99. /
void:: 
Insert::
 
(:: 
TEntity:: 
entity:: "
)::" #
;::# $
Task;; 
<;; 

bool;;
 
>;; 
Update;; 
(;; 
TEntity;; !
entity;;" (
);;( )
;;;) *
Task<< 
<<< 

bool<<
 
><< 
Delete<< 
(<< 
TEntity<< !
entity<<" (
)<<( )
;<<) *
Task== 
<== 

int==
 
>== 
ExecuteCommand==  
(==  !
string==! '
query==( -
)==- .
;==. /
IEnumerable>> 
<>> 
TEntity>> 
>>> 
GetSync>> $
(>>$ %
string>>% +
query>>, 1
)>>1 2
;>>2 3
IEnumerable?? 
<?? 
TEntity?? 
>?? 

GetAllSync?? '
(??' (
)??( )
;??) *
TEntity@@ 
GetByIdSync@@ 
(@@ 
long@@  
id@@! #
)@@# $
;@@$ %
boolAA 

UpdateSyncAA
 
(AA 
TEntityAA 
entityAA  &
)AA& '
;AA' (
}CC 
}EE �
�D:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Domain\Interfaces\Repositories\DBExemplo\ExemploReopsitory.cs
	namespace		 	
Exemplo		
 
.		 
Domain		 
.		 

Interfaces		 #
.		# $
Repositories		$ 0
.		0 1
	DBExemplo		1 :
{

 
public 

	interface 
IPessoaRepository &
:' (
IRepositoryBase) 8
<8 9
Pessoa9 ?
>? @
{A B
}C D
} 