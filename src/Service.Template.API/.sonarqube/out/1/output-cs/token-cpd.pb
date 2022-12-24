�
zD:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Application\Interfaces\IUseCaseReq.cs
	namespace 	
Exemplo
 
. 
Application 
. 

Interfaces (
{ 
public		 

	interface		 
IUseCaseReq		  
<		  !
in		! #
TRequest		$ ,
>		, -
{

 
void 
Execute
 
( 
TRequest 
request %
)% &
;& '
} 
public 

	interface 
IUseCase 
< 
in  
TRequest! )
,) *
out+ .
	TResponse/ 8
>8 9
{ 
	TResponse 
Execute 
( 
TRequest "
request# *
)* +
;+ ,
} 
public 

	interface 
IUseCaseResp !
<! "
out" %
	TResponse& /
>/ 0
{ 
	TResponse 
Execute 
( 
) 
; 
} 
public 

	interface 
IUseCaseReqAsync %
<% &
in& (
TRequest) 1
>1 2
{ 
Task 
ExecuteAsync
 
( 
TRequest "
request# *
)* +
;+ ,
} 
public 

	interface 

IUseCaseAsync "
<" #
in# %
TRequest& .
,. /
	TResponse0 9
>9 :
{ 
Task 
< 

	TResponse
 
> 
ExecuteAsync $
($ %
TRequest% -
request. 5
)5 6
;6 7
}   
public"" 

	interface"" "
IUseCaseAsyncParameter"" +
<""+ ,
in"", .
TRequest""/ 7
,""7 8
	TResponse""9 B
>""B C
{## 
Task$$ 
<$$ 

	TResponse$$
 
>$$ 
ExecuteAsync$$ $
($$$ %
TRequest$$% -
request$$. 5
,$$5 6
int$$7 :
	parameter$$; D
)$$D E
;$$E F
}%% 
public'' 

	interface'' 
IUseCaseRespAsync'' &
<''& '
	TResponse''' 0
>''0 1
{(( 
Task)) 
<)) 

	TResponse))
 
>)) 
ExecuteAsync)) $
())$ %
)))% &
;))& '
}** 
}++ �
}D:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Application\Mappers\AutoMapperProfile.cs
	namespace 	
Exemplo
 
. 
Application 
. 
Mappers %
{ 
public 

class 
AutoMapperProfile "
:# $
Profile% ,
{ 
Template		 
AutoMapperProfile		  
Template	  !
)		! "
{

 	
	CreateMap 
< 
Pessoa 
, 
PessoaResponse ,
>, -
(- .
). /
;/ 0
} 	
}

 
} �	
�D:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Application\Models\Request\JWT\UserRequest.cs
	namespace 	
Exemplo
 
. 
Application 
. 
Models $
.$ %
Request% ,
., -
JWT- 0
{ 
public		 

class		 
UserRequest		 
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
public 
UserRequest 
( 
) 
{ 	
} 	
public 
UserRequest 
( 
Guid 
clientId  (
,( )
string* 0
clientSecret1 =
)= >
{ 	
ClientId TemplateTemplate
= 
clientId 
;  
ClientSecret 
= 
clientSecret '
;' (
} 	
} 
} �
�D:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Application\Models\Request\Pessoa\PessoaBuscaRequest.cs
	namespace		 	
Exemplo		
 
.		 
Templateation		 
.		 
Models		 $
.		$ %
Request		% ,
{

 
public 

class 
PessoaBuscaRequest #
{ 
[

 	
Range

	 
(

 
$num

 
,

 
$num

 
,

 
ErrorMessage

 $
=

% &
$str

' V
)

V W
]

W X
public 
int 

PageNumber 
{ 
get  #
;# $
set% (
;( )
}* +
[ 	
Range	 
( 
$num 
, 
$num 
, 
ErrorMessage $
=% &
$str' W
)W X
]X Y
public 
int 
PageSize 
{ 
get !
;! "
set# &
;& '
}( )
public 
int 
? 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
bool 

FiltraNome 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 

FiltroNome  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
bool  
FiltraDataNascimento (
{) *
Template+ .
;. /
set0 3
;3 4
}5 6
public 
Templateme 
? 
DataInicial $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
DateTime 
? 
	DataFinal "
{# $
get% (TemplateTemplate
;( )
set* -
;- .
}/ 0
public 
int 
Status 
{ 
get 
;  
set! $
;$ %
}& '
public 
PessoaBuscaRequest !
(! "
)" #
Template 	
} 	
public   
PessoaBuscaRequest   !
(  ! "
int  " %
?  Template
id  ' )
)  ) *
{!! 	
Id"Template
="" 
id"" 
;"" 
}##Template
}$$ 
}%% �
�D:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Application\Models\Request\Pessoa\PessoaRequest.cs
	namespace 	
Exemplo
 
. 
Application 
. 
Models $
.$ %
Request% ,
{		 
public

 

class

 

PessoaRequest

 
{ 
private 
bool 

isValidPessoa "
;" #
public

 
bool

 

IsValidPessoa

 !
{ 	
get 
{ 


isValidPessoa 
= 
(  !
( 
( 
EAction !
==" $
EAction% ,
., -
INSERT- 3
)3 4
&&5 7
(8 9
Id9 ;
==< >
null? C
||D F
IdG I
==J L
$numM N
)N O
&&P R
(S T
NomeT X
!=Y [
null\ `
&&a c
Nomed h
.h i
Lengthi o
>p q
$numr s
)s t
&&u w
(x y
DataNascimento	y �
<
� �
DateTime
� �
.
� �
Now
� �
.
� �
AddDays
� �
(
� �
$num
� �
)
� �
)
� �
&&
� �
(
� �
Status
� �
==
� �
$num
� �
)
� �
)
� �
|| 
( 
( 
EAction !
==" $
EAction% ,
., -
UPDATE- 3
)3 4
&&5 7
(8 9
Id9 ;
!=< >
null? C
&&D F
IdG I
!=J L
$numM N
)N O
&&P R
(S T
NomeT X
!=Y [
null\ `
&&a c
Nomed h
.h i
Lengthi o
>p q
$numr s
)s t
&&u w
(x y
DataNasTemplateo	y �
<
� �
DateTime
� �
.
� �
Now
� �
.
� �
AddDays
� �
(
� �
$num
� �
)
� �
)
� �
)
� �
|| 
( 
( 
EAction !
==" $
EAction% ,
., -
DELETE- 3
)3 4
&&5 7
(8 9
Id9 ;
!=< >
null? C
&&D F
IdG I
!=J L
$numM N
)N O
)O P
) 
; 
return 

isValidPessoa $
;$ %
} 

} 	
public 
EAction 
EAction 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
int 
? 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
Nome 
{ 
get  
;  !
set" %
;% &
}' (
public 
DateTime 
DataNascimento &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public   
int   
Status   
{   
get   
;    
set  ! $
;  $ %
}  & '
}!! 
}"" �
�D:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Application\Models\Response\Errors\ErrorResponse.cs
	namespace 	
Exemplo
 
. 
Application 
. 
Models $
.$ %
Response% -
.- .
Errors. 4
{ 
public		 

class		 

ErrorResponse		 
{

 
public 
string 
Id 
{ 
get 
; 
set  #
;# $
}% &
public 
string 
	Parameter 
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
 
Message

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 

ErrorResponse 
( 
) 
{ 	
} 	
public 

ErrorResponse 
( 
string #
id$ &
,& '
string( .
	parameter/ 8
)8 9
{ 	
Id 
= 
id 
; 
	Parameter 
= 
	parameter !
;! "
} 	
public 

ErrorResponse 
( 
string #
id$ &
,& '
string( .
	parameter/ 8
,8 9
string: @
messageA H
)H I
:J K
thisL P
(P Q
idQ S
,S T
	parameterU ^
)^ _
{ 	
Message 
= 
message 
; 
} 	
} 
} �	
�D:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Application\Models\Response\Errors\ErrorsResponse.cs
	namespace 	
Exemplo
 
. 
Application 
. 
Models $
.$ %
Response% -
.- .
Errors. 4
{ 
public		 

class		 
ErrorsResponse		 
{

 
public 
List 
< 

ErrorResponse !
>! "
Errors# )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public

 
ErrorsResponse

 
(

 
)

 
{ 	
Errors 
= 
new 
List 
< 

ErrorResponse +
>+ ,
(, -
)- .
;. /
} 	
public 
ErrorsResponse 
( 
List "
<" #

ErrorResponse# 0
>0 1
errors2 8
)8 9
{ 	
Errors 
= 
errors 
; 
} 	
} 
} �
�D:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Application\Models\Response\JWT\UserOutResponse.cs
	namespace 	
Exemplo
 
. 
Application 
. 
Models $
.$ %
Response% -
.- .
JWT. 1
{ 
public		 

class		 
UserOutResponse		  
:		! "
ResponseBase		# /
{

 
} 
} �
�D:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Application\Models\ResponsTemplateUTemplateponse.cs
	namespace 	
Exemplo
 
. 
Application 
. 
Models $
.$ %
Response% -
.- .
JWT. 1
{ 
public		 
Template
class		 
UserResponse		 
{

 
public 
bool 
Autenticado TemplateTemplate
{  !
get! $
;$ %
set& )
;) *
}+ ,
public 
Guid 
ClientId 
{ 
get "
;" #
set$ '
;' (
}) *
public

 
string

 
Token

 
{

 
get

Template
;

! "
set

# &
;

& '
}

( )
public 
UserResponse 
( 
) 
{ 	
Template 	
public 
Templatesponse 
( 
bool  
autenticado! ,
,, -
Guid. 2
clientId3 ;
,; <
Template= C
tokenD I
)I J
{ 	
Autenticado 
= 
autenticado %
;% &
ClientId 
= 
clientId 
;  
Token 
= 
token 
Template 
} 	
} 
} �
�D:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Application\Models\Response\Pessoa\PessoaOutResponse.cs
	Templateace 	
Exemplo
 
. 
Application 
. 
Models $
Template$ %
Response% -
{ 
public		 

class		 
PessoaOutResponse		 "
:		# $
ResponseBase		% 1
{

Template
} 
} �
�D:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Application\Models\Response\Pessoa\PessoaResponse.cs
	namespace

 	
Exemplo


 
Template

 
Application

 
.

 
Models

 $
.

$ %
Response

% -
{ 
public 

class 
PessoaResponse 
{

 
public 
List 
< 
	Navigator 
> 

Navigators )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
List 
< 
Pessoa 
> 
Pessoas #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
PessoaResponse 
( 
) 
{ 	

Navigators 
= 
new 
List !
<! "
	Navigator" +
>+ ,
(, -
)- .
;. /
Pessoas 
= 
new 
List 
< 
Pessoa %
>% &
(& '
)' (
;( )
} 	
public 
PessoaResponse 
( 
List "
<" #
	Navigator# ,
>, -

navigators. 8
,8 9
List: >
<> ?
Pessoa? E
>E F
pessoasG N
)N O
{ 	

Navigators 
= 

navigators #
;# $
Pessoas 
= 
pessoas 
; 
} 	
} 
} �
�D:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Application\Models\Response\ResponseBase.cs
	namespace 	
Exemplo
 
. 
Application 
. 
Models $
.$ %
Response% -
{		 
public

 

class

 
ResponseBase

 
:

 
IDisposable

  +
{ 
public 
bool 
	Resultado 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
Mensagem 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
object 
Data 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Request 
{ 
get  #
;# $
set% (
;( )
}* +
public 
Errors 
. 
ErrorsResponse $
ErrorsResponse% 3
{4 5
get6 9
;9 :
set; >
;> ?
}@ A
public 
ResponseBase 
( 
) 
{ 	
} 	
public 
ResponseBase 
( 
bool  
	resultado! *
,* +
string, 2
mensagem3 ;
,; <
object= C
dataD H
)H I
{ 	
	Resultado 
= 
	resultado !
;! "
Mensagem 
= 
mensagem 
;  
Data 
= 
data 
; 
} 	
public!! 
ResponseBase!! 
(!! 
bool!!  
	resultado!!! *
,!!* +
string!!, 2
mensagem!!3 ;
,!!; <
object!!= C
data!!D H
,!!H I
ErrorsResponse!!J X
errorsResponse!!Y g
)!!g h
:!!i j
this!!k o
(!!o p
	resultado!!p y
,!!y z
mensagem	!!{ �
,
!!� �
data
!!� �
)
!!� �
{"" 	
ErrorsResponse## 
=## 
errorsResponse## +
;##+ ,
}$$ 	
public&& 
ResponseBase&& 
(&& 
bool&&  
	resultado&&! *
,&&* +
string&&, 2
mensagem&&3 ;
,&&; <
object&&= C
data&&D H
,&&H I
string&&J P
request&&Q X
,&&X Y
ErrorsResponse&&Z h
errorsResponse&&i w
)&&w x
:&&y z
this&&{ 
(	&& �
	resultado
&&� �
,
&&� �
mensagem
&&� �
,
&&� �
data
&&� �
)
&&� �
{'' 	
Request(( 
=(( 
request(( 
;(( 
ErrorsResponse)) 
=)) 
errorsResponse)) +
;))+ ,
}** 	
public11 
void11 
Dispose11 
(11 
)11 
{22 	
Dispose33 
(33 
true33 
)33 
;33 
GC44 
.44 
SuppressFinalize44 
(44  
this44  $
)44$ %
;44% &
}55 	
	protected77 
virtual77 
void77 
Dispose77 &
(77& '
bool77' +
	disposing77, 5
)775 6
{88 	
}:: 	
~<< 	
ResponseBase<<	 
(<< 
)<< 
{== 	
Dispose>> 
(>> 
false>> 
)>> 
;>> 
}?? 	
}AA 
}BB �X
�D:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Application\UseCases\JWT\AutenticarUserUseCaseAsync.cs
	namespace 	
Exemplo
 
. 
Application 
. 
UseCases &
.& '
JWT' *
{ 
public 

class &
AutenticarUserUseCaseAsync +
:, -

IUseCaseAsync. ;
<; <
UserRequest< G
,G H
UserOutResponseI X
>X Y
,Y Z
IDisposable[ f
{ 
private 
IConfiguration 
_configuration -
;- .
public &
AutenticarUserUseCaseAsync )
() *
IConfiguration* 8

configuration9 F
)F G
{ 	
_configuration 
= 

configuration *
;* +
} 	
private 
async 
Task 
< 
bool 
>  
ValidaParamentos! 1
(1 2
UserRequest2 =
request> E
)E F
{ 	
if 
( 
! 
string 
. 

IsNullOrEmpty %
(% &
ValidaRequestUser& 7
(7 8
request8 ?
)? @
)@ A
)A B
returnC I
falseJ O
;O P
User 
user 
= 
new 
( 
new 
Guid  $
($ %
_configuration% 3
[3 4
$str4 ?
]? @
)@ A
,B C
_configurationD R
[R S
$strS b
]b c
)c d
;d e
bool!! 
isValidToken!! 
=!! 
(!!  !
(!!! "
request!!" )
.!!) *
ClientId!!* 2
==!!3 5
user!!6 :
.!!: ;
ClientId!!; C
)!!C D
&&!!E G
(!!H I
request!!I P
.!!P Q
ClientSecret!!Q ]
==!!^ `
user!!a e
.!!e f
ClientSecret!!f r
)!!r s
)!!s t
;!!t u
return## 
isValidToken## 
;##  
}$$ 	
public&& 
async&& 
Task&& 
<&& 
UserOutResponse&& )
>&&) *
ExecuteAsync&&+ 7
(&&7 8
UserRequest&&8 C
request&&D K
)&&K L
{'' 	
UserOutResponse(( 
output(( "
=((# $
new((% (
(((( )
)(() *
;((* +
var)) 
validaParametros))  
=))! "
await))# (
ValidaParamentos))) 9
())9 :
request)): A
)))A B
;))B C
if++ 
(++ 
!++ 
validaParametros++ !
)++! "
{,, 

output-- 
.-- 
	Resultado--  
=--! "
false--# (
;--( )
output.. 
... 
Mensagem.. 
=..  !
$@".." %
$str..% 6
"..6 7
;..7 8
output// 
.// 
Data// 
=// 
null// "
;//" #
return11 
output11 
;11 
}22 

try44 
{55 

var66 

tokenValue66 
=66  
_configuration66! /
.66/ 0

GetSection660 :
(66: ;
$str66; C
)66C D
.66D E

GetSection66E O
(66O P
$str66P X
)66X Y
.66Y Z
Value66Z _
;66_ `
var88 
tokenHandler88  
=88! "
new88# &#
JwtSecurityTokenHandler88' >
(88> ?
)88? @
;88@ A
var99 
key99 
=99 
Encoding99 "
.99" #
ASCII99# (
.99( )
GetBytes99) 1
(991 2

tokenValue992 <
)99< =
;99= >
var:: 
tokenDescriptor:: #
=::$ %
new::& )#
SecurityTokenDescriptor::* A
{;; 
Expires<< 
=<< 
DateTime<< &
.<<& '
UtcNow<<' -
.<<- .
AddHours<<. 6
(<<6 7
$num<<7 8
)<<8 9
,<<9 :
SigningCredentials== &
===' (
new==) ,
SigningCredentials==- ?
(==? @
new==@ C 
SymmetricSecurityKey==D X
(==X Y
key==Y \
)==\ ]
,==] ^
SecurityAlgorithms==_ q
.==q r 
HmacSha256Signature	==r �
)
==� �
}>> 
;>> 
var?? 
token?? 
=?? 
tokenHandler?? (
.??( )
CreateToken??) 4
(??4 5
tokenDescriptor??5 D
)??D E
;??E F
var@@ 
strToken@@ 
=@@ 
tokenHandler@@ +
.@@+ ,

WriteToken@@, 6
(@@6 7
token@@7 <
)@@< =
;@@= >
UserResponseBB 
userResponseBB )
=BB* +
newBB, /
UserResponseBB0 <
(BB< =
trueBB= A
,BBA B
requestBBC J
.BBJ K
ClientIdBBK S
,BBS T
strTokenBBU ]
)BB] ^
;BB^ _
outputDD 
.DD 
	ResultadoDD  
=DD! "
trueDD# '
;DD' (
outputEE 
.EE 
MensagemEE 
=EE  !
$@"EE" %
$strEE% 2
"EE2 3
;EE3 4
outputFF 
.FF 
DataFF 
=FF 
userResponseFF *
;FF* +
returnGG 
outputGG 
;GG 
}HH 

catchII 
(II 
ArgumentExceptionII $
argExII% *
)II* +
{JJ 

outputKK 
.KK 
	ResultadoKK  
=KK! "
falseKK# (
;KK( )
outputLL 
.LL 
MensagemLL 
=LL  !
argExLL" '
.LL' (
MessageLL( /
;LL/ 0
throwMM 
newMM 
ArgumentExceptionMM +
(MM+ ,
argExMM, 1
.MM1 2
MessageMM2 9
)MM9 :
;MM: ;
}NN 

catchOO 
(OO 
	ExceptionOO 
exOO 
)OO  
{PP 

outputQQ 
.QQ 
	ResultadoQQ  
=QQ! "
falseQQ# (
;QQ( )
outputRR 
.RR 
MensagemRR 
=RR  !
exRR" $
.RR$ %
MessageRR% ,
;RR, -
returnSS 
outputSS 
;SS 
}TT 

}UU 	
privateWW 
stringWW 
ValidaRequestUserWW (
(WW( )
UserRequestWW) 4
requestWW5 <
)WW< =
{XX 	
tryYY 
{ZZ 

string[[ 
result[[ 
=[[ 
$str[[  "
;[[" #
bool\\ 
isClientIdValid\\ $
=\\% &
Guid\\' +
.\\+ ,
TryParse\\, 4
(\\4 5
request\\5 <
.\\< =
ClientId\\= E
.\\E F
ToString\\F N
(\\N O
)\\O P
,\\P Q
out\\R U
Guid\\V Z
guidClientId\\[ g
)\\g h
;\\h i
bool^^ 
isClientSecretValid^^ (
=^^) *
(^^+ ,
!^^, -
String^^- 3
.^^3 4

IsNullOrEmpty^^4 A
(^^A B
request^^B I
.^^I J
ClientSecret^^J V
)^^V W
)^^W X
;^^X Y
result`` 
=`` 
$@"`` 
{`` 
(`` 
isClientIdValid`` -
?``. /
(``0 1
$str``1 3
)``3 4
:``5 6
$@"``7 :
$str``: \
"``\ ]
)``] ^
}``^ _
"``_ `
;``` a
resultbb 
=bb 
$@"bb 
{bb 
(bb 
isClientSecretValidbb 1
?bb2 3
(bb4 5
$@"bb5 8
{bb8 9
resultbb9 ?
}bb? @
"bb@ A
)bbA B
:bbC D
$@"bbE H
{bbH I
resultbbI O
}bbO P
$strbbP w
"bbw x
)bbx y
}bby z
"bbz {
;bb{ |
resultdd 
=dd 
$@"dd 
{dd 
(dd 
(dd 
requestdd &
.dd& '
ClientIddd' /
==dd0 2
newdd3 6
Guiddd7 ;
(dd; <
_configurationdd< J
.ddJ K

GetSectionddK U
(ddU V
$strddV ^
)dd^ _
.dd_ `

GetSectiondd` j
(ddj k
$strddk o
)ddo p
.ddp q
Valueddq v
)ddv w
)ddw x
?ddy z
(dd{ |
$@"dd| 
{	dd �
result
dd� �
}
dd� �
"
dd� �
)
dd� �
:
dd� �
(
dd� �
$@"
dd� �
{
dd� �
result
dd� �
}
dd� �
$str
dd� �
"
dd� �
)
dd� �
)
dd� �
}
dd� �
"
dd� �
;
dd� �
resultff 
=ff 
$@"ff 
{ff 
(ff 
(ff 
requestff &
.ff& '
ClientSecretff' 3
==ff4 6
_configurationff7 E
.ffE F

GetSectionffF P
(ffP Q
$strffQ Y
)ffY ZTemplateTemplate
.ffZ [

GetSectionff[ e
(ffe f
$strfff n
)ffn o
.ffo p
Valueffp u
Templatefu v
?ffw x
(ffy z
$@"ffz }
{ff} ~
resTemplateff~ �
}
ff� �
"
Template �
)
Template �
:
ff� �
(
ff� �
$@"
fTemplate�
{
ff� �
result
ffTemplate
}
fTemplate�
$str
ff� �
"
ff� �
)
ff� �
)
ff� �
}
ff� �
"
ff� �
Template
ff� �
returnhh 
resulthh 
Templateh 
}ii 

catchjj 
Templatej 
	Exceptionjj 
exjj 
)jj  
Templatek 

throwll 
newll 
ArgumentExceptionll +
(ll+ ,
exll, .
.ll. /
Messagell/ 6
)ll6 7
;ll7 8
}mm 

}nn 	
publicqqTemplate
voidqq 
Disposeqq 
(qq 
)qq 
{rr 	
Disposess 
(ss 
truess 
)ss 
;ss 
GCtt 
.tt 
SuppressFinalizett 
(tt  
thistt  $
)tt$ %
;tt% &
}uu 	
	protectedww 
virtualww 
voidww 
Disposeww &
(ww& '
Templateww' +
	disposingww, 5
Templatew5 6
{xx 	
_configurationyy 
=yy 
nullyy !
;yy! "
}zz 	
~|| 	&
AutenticarUserUseCaseAsync||	 #
(||# $
)||$ %
{}} 	
Dispose~~ 
(~~ 
false~~ 
)~~ 
;~~ 
} 	
}
�� 
}�� ��
�D:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Application\UseCases\Pessoa\GetPessoaUseCaseAsync.cs
	namespace 	
Exemplo
 
. 
Application 
. 
UseCases &
.& '
Pessoa' -
{

 
public 

class !
GetPessoaUseCaseAsync &
:' (

IUseCaseAsync) 6
<6 7
PessoaBuscaRequest7 I
,I J
PessoaOutResponseK \
>\ ]
,] ^
IDisposable_ j
{ 
private 
IPessoaRepository !
_pessoaRepository" 3
;3 4
public !
GetPessoaUseCaseAsync $
($ %
IPessoaRepository% 6
pessoaRepository7 G
)G H
{ 	
_pessoaRepository 
= 
pessoaRepository  0
;0 1
} 	
public 
async 
Task 
< 
PessoaOutResponse +
>+ ,
ExecuteAsync- 9
(9 :
PessoaBuscaRequest: L
requestM T
)T U
{ 	
PessoaOutResponse 
output $
=% &
new' *
PessoaOutResponse+ <
{ 

	Resultado 
= 
false !
} 

;
 
if 
( 
! 
string 
. 

IsNullOrEmpty %
(% &
ValidaRequestPessoa& 9
(9 :
request: A
)A B
)B C
)C D
returnE K
outputL R
;R S
try   
{!! 

if"" 
("" 
request"" 
."" 
Id"" 
!="" !
null""" &
)""& '
{## 
Domain$$ 
.$$ 
Entities$$ #
.$$# $
Pessoa$$$ *
.$$* +
Pessoa$$+ 1
pessoa$$2 8
=$$9 :
await$$; @
_pessoaRepository$$A R
.$$R S
GetById$$S Z
($$Z [
request$$[ b
.$$b c
Id$$c e
.$$e f
Value$$f k
)$$k l
;$$l m
output&& 
.&& 
	Resultado&& $
=&&% &
true&&' +
;&&+ ,
output'' 
.'' 
Mensagem'' #
=''$ %
$str''& D
;''D E
output(( 
.(( 
Data(( 
=((  !
pessoa((" (
;((( )
})) 
else** 
{++ 
string-- 
_query-- !
=--" #
String--$ *
.--* +
Empty--+ 0
;--0 1
string.. 
_where.. !
=.." #
String..$ *
...* +
Empty..+ 0
;..0 1
string00 
tabela00 !
=00" #
$@"00$ '
$str00' -
"00- .
;00. /
string11 
select11 !
=11" #
$@"11$ '
$str	11' �
{
11� �
tabela
11� �
}
11� �
$str
11� �
"
11� �
;
11� �
if33 
(33 
request33 
.33  

PageNumber33  *
<=33+ -
$num33. /
)33/ 0
{331 2
request333 :
.33: ;

PageNumber33; E
=33F G
$num33H I
;33I J
}33K L
if44 
(44 
request44 
.44  
PageSize44  (
<=44+ -
$num44. /
)44/ 0
{441 2
request443 :
.44: ;
PageSize44; C
=44F G
$num44H I
;44I J
}44K L
string77 
	whereNome77 $
=77% &
String77' -
.77- .
Empty77. 3
;773 4
if88 
(88 
request88 
.88  

FiltraNome88  *
&&88+ -
(88. /
(88/ 0
request880 7
.887 8

FiltroNome888 B
!=88C E
null88F J
)88J K
&&88L N
(88O P
request88P W
.88W X

FiltroNome88X b
.88b c
Trim88c g
(88g h
)88h i
.88i j
Length88j p
>88q r
$num88s t
)88t u
)88u v
)88v w
{99 
	whereNome:: !
=::" #
$@"::$ '
$str::' D
{::D E
request::E L
.::L M

FiltroNome::M W
}::W X
$str::X e
"::e f
;::f g
};; 
string== 
whereDataNascimento== .
===/ 0
String==1 7
.==7 8
Empty==8 =
;=== >
if>> 
(>> 
(>> 
request>>  
.>>  ! 
FiltraDataNascimento>>! 5
)>>5 6
&&>>7 9
(>>: ;
request>>; B
.>>B C
DataInicial>>C N
!=>>O Q
null>>R V
&&>>W Y
request>>Z a
.>>a b
	DataFinal>>b k
!=>>l n
null>>o s
)>>s t
)>>t u
{?? 
DateTime@@  
aux@@! $
;@@$ %
ifBB 
(BB 
requestBB #
.BB# $
DataInicialBB$ /
>BB0 1
requestBB2 9
.BB9 :
	DataFinalBB: C
)BBC D
{CC 
auxDD 
=DD  !
requestDD" )
.DD) *
DataInicialDD* 5
.DD5 6
ValueDD6 ;
;DD; <
requestEE #
.EE# $
DataInicialEE$ /
=EE0 1
requestEE2 9
.EE9 :
	DataFinalEE: C
;EEC D
requestFF #
.FF# $
	DataFinalFF$ -
=FF. /
auxFF0 3
;FF3 4
}GG 
whereDataNascimentoII +
=II, -
$@"II. 1
$strII1 T
{IIT U
requestIIU \
.II\ ]
DataInicialII] h
.IIh i
ValueIIi n
:IIn o
$strIIo y
}IIy z
{IIz {
$@"II{ ~
$str	II~ �
"
II� �
}
II� �
$str
II� �
{
II� �
request
II� �
.
II� �
	DataFinal
II� �
.
II� �
Value
II� �
:
II� �
$str
II� �
}
II� �
{
II� �
$@"
II� �
$str
II� �
"
II� �
}
II� �
$str
II� �
"
II� �
;
II� �
}KK 
_whereMM 
=MM 
$@"MM  
$strMN  
{NN 
_whereNN 
}NN  
$strNP  
{PP 
(PP 
(PP 
	whereNomePP $
.PP$ %
TrimPP% )
(PP) *
)PP* +
.PP+ ,
LengthPP, 2
>PP3 4
$numPP5 6
)PP6 7
?PP8 9
(PP: ;
$@"PP; >
$strPP> J
{PPJ K
	whereNomePPK T
}PPT U
$strPPU X
"PPX Y
)PPY Z
:PP[ \
(PP] ^
$@"PP^ a
"PPa b
)PPb c
)PPc d
}PPd e
$strPRe 
{RR 
(RR 
(RR 
whereDataNascimentoRR .
.RR. /
TrimRR/ 3
(RR3 4
)RR4 5
.RR5 6
LengthRR6 <
>RR= >
$numRR? @
)RR@ A
?RRB C
(RRD E
$@"RRE H
$strRRH T
{RRT U
TemplateataNascimentoRRU h
}RRh i
$strRRi l
"RRl m
TemplateRm n
:RRo p
(RRq r
$@"RRr u
"RRu v
)RRv w
)RRw x
}RRx y
$strRTy 
"TT 
;TT 
_queryVV 
=VV 
$@"VV  
$strVX  ;
{XX; <
requestXX< C
.XXC D

PageNumberXXD N
}XXN O
$strXYO ;
{YY; <
requestYY< C
.YYC D
PageSizeYYD L
}YYL M
$strY`M 
{`` 
_where`` 
}``  
$str	`�  >
{
��> ?
select
��? E
}
��E F
$str
��F 
"
Template 
;
�� 
var
�� $
navigatorNovosCasosLog
�� .
=
Template/ 0
_pessoaRepository
��1 B
.
��B C
GetMultiple
��C N
(
��N O
_query
��O U
,
��U V
new
��W Z
{
��[ \
param
��] b
=
��c d
$str
��e g
}
��h i
,
��i j
gr
��  "
=>
��# %
gr
��& (
.
��( )
Read
��) -
<
��- .
	Navigator
��. 7
>
��7 8
(
��8 9
)
��9 :
,
�� 
gr
��  "
=>
��# %
gr
��& (
.
��( )
Read
��) -
<
��- .
Exemplo
��. 5
.
��5 6
Domain
��6 <
.
��< =
Entities
��= E
.
��E F
Pessoa
��F L
.
��L M
Pessoa
��M S
>
��S T
(
��T U
)
��U V
)
�� 
Template
��  
var
�� 
Template
navigators
�� "
=
��# $$
navigatorNovosCasosLog
��% ;
.
��; <
Item1
��< A
;
��A B
var
�� 
pessoas
Template 
=
��  !$
navigatorNovosCasosLog
��" 8
.
��8 9
Item2
��9 >
;
��> ?
PessoaResponse
�� "
pessoaResponse
��# 1
=
��2 3
new
Template4 7
PessoaResponse
��8 F
(
TemplateF G
)
��G H
;
��H I
foreach
�� 
(
�� 
	Navigator
�� &
	navigator
��' 0
in
��1 3

navigators
��4 >
)
��> ?
{
�� 
pessoaResponse
�� &
.
��& '

Navigators
��' 1
.
��1 2
Add
��2 5
(
��5 6
new
��6 9
	Navigator
��: C
(
��C D
	navigator
��D M
.
��M N
RecordCount
��N Y
,
��Y Z
	navigator
��[ d
.
��d e

PageNumber
��e o
,
��o p
	navigator
��q z
.
��z {
PageSize��{ �
,��� �
	navigator��� �
.��� �
	PageCount��� �
)��� �
)��� �
;��� �
}
�� 
foreach
�� 
(
�� 
Domain
�� #
.
��# $
Entities
��$ ,
.
��, -
Pessoa
��- 3
.
��3 4
Pessoa
��4 :
pessoa
��; A
in
��B D
pessoas
��E L
)
��L M
{
�� 
pessoaResponse
�� &
.
��& '
Pessoas
��' .
.
��. /
Add
��/ 2
(
��2 3
new
��3 6
Domain
��7 =
.
��= >
Entities
��> F
.
��F G
Pessoa
��G M
.
��M N
Pessoa
��N T
(
��T U
pessoa
��U [
.
��[ \
Id
��\ ^
,
��^ _
pessoa
��` f
.
��f g
Nome
��g k
,
��k l
pessoa
��m s
.
��s t
DataNascimento��t �
,��� �
pessoa��� �
.��� �
Status��� �
,��� �
pessoa��� �
.��� �

DataInsert��� �
.��� �
Value��� �
,��� �
pessoa��� �
.��� �

DataUpdate��� �
.��� �
Value��� �
)��� �
)��� �
;��� �
}
�� 
if
�� 
(
�� 

navigators
�� "
.
��" #
Any
��# &
(
��& '
)
��' (
&&
��) +
pessoas
��, 3
.
��3 4
Any
��4 7
(
��7 8
)
��8 9
)
��9 :
{
�� 
output
�� 
.
�� 
	Resultado
�� (
=
��) *
true
��+ /
;
��/ 0
output
�� 
.
�� 
Mensagem
�� '
=
��( )
$str
��* I
;
��I J
output
�� 
.
�� 
Data
�� #
=
��$ %
pessoaResponse
��& 4
;
��4 5
}
�� 
else
�� 
{
�� 
output
�� 
.
�� 
	Resultado
�� (
=
��) *
false
��+ 0
;
��0 1
output
�� 
.
�� 
Mensagem
�� '
=
��( )
$str
��* C
;
��C D
}
�� 
return
�� 
output
�� !
;
��! "
}
�� 
}
�� 

catch
�� 
(
�� 
	Exception
�� 
ex
�� 
)
��  
{
�� 

Models
�� 
.
�� 
Response
�� 
.
��  
Errors
��  &
.
��& '

ErrorResponse
��' 4

errorResponse
��5 B
=
��C D
new
��E H
Models
��I O
.
��O P
Response
��P X
.
��X Y
Errors
��Y _
.
��_ `

ErrorResponse
��` m
(
��m n
$str
��n r
,
��r s
$str
��t 
,�� �
JsonConvert��� �
.��� �
SerializeObject��� �
(��� �
ex��� �
,��� �

Formatting��� �
.��� �
Indented��� �
)��� �
)��� �
;��� �
System
�� 
.
�� 
Collections
�� "
.
��" #
Generic
��# *
.
��* +
List
��+ /
<
��/ 0
Models
��0 6
.
��6 7
Response
��7 ?
.
��? @
Errors
��@ F
.
��F GTemplate

ErrorResponse
��G T
Template
��T U
errorResponses
��V d
=
��e f
new
��g j
System
��k q
.
��q r
Collections
��r }
.
��} ~
Generic��~ �
.��� �
List��� �
<��� �
Models��� �
.��� �
Response��� �
.��� �
Errors��� �
.��� �

ErrorResponse��� �
>��� �
(��� �
)��� �
;��� �
errorResponses
�� 
.
�� 
Add
�� "
(
��" #

errorResponse
��# 0
)
��0 1
;
��1 2
output
�� 
.
�� 
ErrorsResponse
�� %
=
��& '
new
��( +
Models
��, 2
.
��2 3
Response
��3 ;
.
��; <
Errors
��< B
.
��B C
ErrorsResponse
��C Q
(
��Q R
errorResponses
��R `
)
��` a
;
��a b
}
�� 

finally
�� 
{
�� 

output
�� 
.
�� 
Request
�� 
=
��  
JsonConvert
��! ,
.
��, -
SerializeObject
��- <
(
��< =
request
��= D
,
��D E

Formatting
��F P
.
��P Q
Indented
��Q Y
)
��Y Z
;
��Z [
}
�� 

return
�� 
output
�� 
;
�� 
}
�� 	
private
�� 
string
�� !
ValidaRequestPessoa
�� *
(
��* + 
PessoaBuscaRequest
��+ =
request
��> E
)
��E F
{
�� 	
try
�Template
{
�� 


StringBuilder
�� 
validationError
�� -
=
��. /
new
��0 3

StringBuilder
��4 A
(
��A B
)
��B C
;
��C D
return
�� TemplateTemplate
validationError
�� &
.
��& '
ToString
��' /
(
��/ 0
Template
��0 1
;
��1 2
}
Template 

catch
�� 
Template
�� 
	Templateion
�� 
ex
�� 
)
��  
{
�� 

throw
�Template 
new
�� 
ArgumentException
�� +
(
Template+ ,
ex
Template, .
.
��Template
Message
��/ 6
Template
��6 7
;
��7 8
}
�� 

Template
�� 	
Template
�� 
voiTemplate
�� 
DTemplate
�� 
(
�� 
)
�� 
{
�� 	
DispTemplate
�� 
(Template
�� 
true
�� 
)
�� 
;
�� 
GC
�� 
.
Template 
SuppressFinalize
�� 
(
Template  
this
��  $
)
Template$ %
;
��% &
}
�� 	
	protected
�� 
virtual
�� 
void
�� 
Dispose
�� &
(
��& '
bool
��' +
	disposing
��, 5
)
��5 6
{Template
�� 	
_pessoaRepository
�� 
=
�� 
null
��  $
;
Template$ %
}
Template 	
~
�� 	#
GetPessoaUseCaseAsync
��	 
(
�� 
)
��  
{
�� 	
Dispose
�� 
(
�� 
false
�� 
)
�� 
;
�� 
}
�� 	
}
�� 
}�� �]
�D:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.Application\UseCases\Pessoa\PessoaUseCaseAsync.cs
	namespace

 	
Exemplo


 
.

 
Application

 
.

 
UseCases

 &
.

& '
Template

' -
{ 
publTemplate 

class 
PessoaUseCaseAsync #
:$ %
Template
IUseCaseAsync& 3
<3 4

PessoaRequest4 A
,A B
PessoaOutResponseC T
>T U
,U V
IDisposableW b
{ 
private 
IMapper 
_mapper 
;  
private 
IPessoaRepository !
_pessoaRepository" 3
;3 4
private 

IUseCaseAsync 
< 
PessoaBuscaRequest 0
,0 1
PessoaOutResponse2 C
>C D"
_getPessoaUseCaseAsyncE [
;[ \
public 
PessoaUseCaseAsync !
(! "
IMapper 
mapper 
, 
Template

ITemplateeAsync 
< 
PessoaBuscaRequest .
,. /
PessoaOutResponse0 A
>A B!
getPessoaUseCaseAsyncC X
, 

IPessoaRepository 
pessoaRepository  0
) 	
{ 	
_mapper 
= 
mapper 
; "
_getPessoaUseCaseAsync "
=# $!
getPessoaUseCaseAsync% :
;: ;
_pessoaRepository 
= 
pessoaRepository  0
;0 1
} 	
public   
async   
Task   
<   
PessoaOutResponse   +
>  + ,
ExecuteAsync  - 9
(  9 :

PessoaRequest  : G
request  H O
)  O P
{!! 	
PessoaOutResponse"" 
output"" $
=""% &
new""' *
(""* +
)""+ ,
{## 

	Resultado$$ 
=$$ 
false$$ !
,$$! "
Mensagem%% 
=%% 
$str%% <
}&& 

;&&
 
if(( 
((( 
!(( 
request(( 
.(( 

IsValidPessoa(( &
)((& '
return((( .
output((/ 5
;((5 6
Domain** 
.** 
Entities** 
.** 
Pessoa** "
.**" #
Pessoa**# )
pessoa*** 0
=**1 2
new**3 6
(**6 7
)**7 8
;**8 9
if,, 
(,, 
(,, 
request,, 
.,, 
EAction,,  
==,,! #
Domain,,$ *
.,,* +
Enum,,+ /
.,,/ 0
EAction,,0 7
.,,7 8
UPDATE,,8 >
),,> ?
||,,@ B
(,,C D
request,,D K
.,,K L
EAction,,L S
==,,T V
Domain,,W ]
.,,] ^
Enum,,^ b
.,,b c
EAction,,c j
.,,j k
DELETE,,k q
),,q r
),,r s
{-- 

if.. 
(.. 
request.. 
... 
Id.. 
==.. !
null.." &
)..& '
return..( .
output../ 5
;..5 6
PessoaOutResponse00 !
pessoaOutResponse00" 3
=004 5
await006 ;"
_getPessoaUseCaseAsync00< R
.00R S
ExecuteAsync00S _
(00_ `
new00` c
PessoaBuscaRequest00d v
(00v w
request00w ~
.00~ 
Id	00 �
.
00� �
Value
00� �
)
00� �
)
00� �
;
00� �
if22 
(22 
!22 
pessoaOutResponse22 &
.22& '
	Resultado22' 0
)220 1
return222 8
output229 ?
;22? @
pessoa44 
=44 
_mapper44  
.44  !
Map44! $
<44$ %
Domain44% +
.44+ ,
Entities44, 4
.444 5
Pessoa445 ;
.44; <
Pessoa44< B
>44B C
(44C D
pessoaOutResponse44D U
.44U V
Data44V Z
)44Z [
;44[ \
}55 

Template77 
{88 
Template
if99 
(99 
request99 
.99 
EAction99 #
==99$ &
Domain99' -
.99- .
Enum99. 2
.992 3
EAction993 :
.99: ;
INSERT99; A
)99A B
{:: 
pessoa;; 
.;; 
Nome;; 
=;;  !
request;;" )
.;;) *
Nome;;* .
;;;. /
pessoa<< 
.<< 
DataNascimento<< )
=<<* +
DateTime<<, 4
.<<4 5
Parse<<5 :
(<<: ;
request<<; B
.<<B C
DataNascimento<<C Q
.<<Q R
ToString<<R Z
(<<Z [
$str<<[ p
)<<p q
)<<q r
;<<r s
pessoa== 
.== 
Status== !
===" #
request==$ +
.==+ ,
Status==, 2
;==2 3
pessoa>> 
.>> 

DataInsert>> %
=>>& '
DateTime>>( 0
.>>0 1
Parse>>1 6
(>>6 7
DateTime>>7 ?
.>>? @
Now>>@ C
.>>C D
ToString>>D L
(>>L M
$str>>M b
)>>b c
)>>c d
;>>d e
_pessoaRepository@@ %
.@@% &
Insert@@& ,
(@@, -
pessoa@@- 3
)@@3 4
;@@4 5
ifBB 
(BB 
pessoaBB 
.BB 
IdBB !
>BB" #
$numBB$ %
)BB% &
{CC 
outputDD 
.DD 
MensagemDD '
=DD( )
$strDD* J
;DDJ K
outputEE 
.EE 
DataEE #
=EE$ %
pessoaEE& ,
;EE, -
outputFF 
.FF 
	ResultadoFF (
=FF) *
trueFF+ /
;FF/ 0
}GG 
}HH 
elseII 
ifII 
(II 
requestII  
.II  !
EActionII! (
==II) +
DomainII, 2
.II2 3
EnumII3 7
.II7 8
EActionII8 ?
.II? @
UPDATEII@ F
)IIF G
{JJ 
pessoaKK 
.KK 
NomeKK 
=KK  !
requestKK" )
.KK) *
NomeKK* .
;KK. /
pessoaLL 
.LL 
DataNascimentoLL )
=LL* +
requestLL, 3
.LL3 4
DataNascimentoLL4 B
;LLB C
pessoaMM 
.MM 
StatusMM !
=MM" #
requestMM$ +
.MM+ ,
StatusMM, 2
;MM2 3
pessoaNN 
.NN 

DataUpdateNN %
=NN& '
DateTimeNN( 0
.NN0 1
ParseNN1 6
(NN6 7
DateTimeNN7 ?
.NN? @
NowNN@ C
.NNC D
ToStringNND L
(NNL M
$strNNM b
)NNb c
)NNc d
;NNd e
pessoaPP 
=PP 
newPP  
DomainPP! '
.PP' (
EntitiesPP( 0
.PP0 1
PessoaPP1 7
.PP7 8
PessoaPP8 >
(PP> ?
requestPP? F
.PPF G
IdPPG I
.PPI J
ValuePPJ O
,PPO P
requestPPQ X
.PPX Y
NomePPY ]
,PP] ^
requestPP_ f
.PPf g
DataNascimentoPPg u
,PPu v
requestPPw ~
.PP~ 
Status	PP �
)
PP� �
;
PP� �
ifRR 
(RR 
awaitRR 
_pessoaRepositoryRR /
.RR/ 0
UpdateRR0 6
(RR6 7
pessoaRR7 =
)RR= >
)RR> ?
{SS 
outputTT 
.TT 
MensagemTT '
=TT( )
$strTT* J
;TTJ K
outputUU 
.UU 
DataUU #
=UU$ %
awaitUU& +
_pessoaRepositoryUU, =
.UU= >
GetByIdUU> E
(UUE F
pessoaUUF L
.UUL M
IdUUM O
)UUO P
;UUP Q
outputVV 
.VV 
	ResultadoVV (
=VV) *
trueVV+ /
;VV/ 0
}WW 
}XX 
elseYY 
ifYY 
(YY 
requestYY  
.YY  !
EActionYY! (
==YY) +
DomainYY, 2
.YY2 3
EnumYY3 7
.YY7 8
EActionYY8 ?
.YY? @
DELETEYY@ F
&&YYG I
awaitYYJ O
_pessoaRepositoryYYP a
.Templateb
DeleteYYb h
(YYh i
pessoaYYi o
)YYo p
)YYp q
{ZZ 
Template[[ 
.[[ 
Mensagem[[ #
=[[$ %
$str[[& F
;[[F G
output\\ 
.\\ 
	Resultado\\ $
=\\% &
true\\' +
;\\+ ,
}]] 
}^^ 

catch__ 
(__ 
	Exception__ 
ex__ 
)__  
{`` 

Modelsaa 
.aa 
Responseaa 
.aa  
Errorsaa  &
.aa& '

ErrorResponseaa' 4

errorResponseaa5 B
=aaC D
newaaE H
(aaH I
$straaI M
,aaM N
$straaO Z
,aaZ [
JsonConvertaa\ g
.aag h
SerializeObjectaah w
(aaw x
exaax z
,aaz {

Formatting	aa| �
.
aa� �
Indented
aa� �
)
aa� �
)
aa� �
;
aa� �
Systembb 
.bb 
Collectionsbb "
.bb" #
Genericbb# *
.bb* +
Listbb+ /
<bb/ 0
Modelsbb0 6
.bb6 7
Responsebb7 ?
.bb? @
Errorsbb@ F
.bbF G

ErrorResponsebbG T
>bbT U
errorResponsesbbV d
=bbe f
newbbg j
(bbj k
)bbk l
{cc 

errorResponsedd !
}ee 
;ee 
outputff 
.ff 
ErrorsResponseff %
=ff& '
newff( +
Modelsff, 2
.ff2 3
Responseff3 ;
.ff; <
Errorsff< B
.ffB C
ErrorsResponseffC Q
(ffQ R
errorResponsesffR `
)ff` a
;ffa b
outputhh 
.hh 
Mensagemhh 
=hh  !
$strhh" L
;hhL M
outputii 
.ii 
	Resultadoii  
=ii! "
falseii# (
;ii( )
}jj 

finallykk 
{ll 

outputmm 
.mm 
Requestmm 
=mm  
JsonConvertmm! ,
.mm, -
SerializeObjectmm- <
(mm< =
requestmm= D
,mmD E

FormattingmmF P
.mmP Q
IndentedmmQ Y
)mmY Z
;mmZ [
}nn 

returnpp 
outputpp 
;pp 
}qq 	
publicss 
voidss 
Disposess 
(ss 
)ss 
{tt 	
Disposeuu 
(uu 
trueuu 
)uu 
;uu 
GCvv 
.vv 
SuppressFinalizevv 
(vv  
thisvv  $
)vv$ %
;vv% &
}ww 	
	protectedyy 
virtualyy 
voidyy 
Disposeyy &
(yy& '
boolyy' +
	disposingyy, 5
)yy5 6
{zz 	
_mapper{{ 
={{ 
null{{ 
;{{ 
_pessoaRepository|| 
=|| 
null||  $
;||$ %"
_getPessoaUseCaseAsync}} "
=}}# $
null}}% )
;}}) *
}~~ 	
~
�� 	 
PessoaUseCaseAsync
��	 
(
�� 
)
�� 
{
�� 	
Dispose
�� 
(
�� 
false
�� 
)
�� 
;
�� 
}
�� 	
}
�� 
}�� 