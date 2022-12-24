�
uD:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.API\Controllers\ApiController.cs
	namespace

 	
Exemplo


 
.

 
API

 
.

 
Controllers

 !
{ 
public 

class 

ApiController 
:  

Controller! +
{

 
public 
override 
void 
OnActionExecuting .
(. /"
ActionExecutingContext/ E
contextF M
)M N
{ 	
if 
( 
! 
context 
. 

ModelState #
.# $
IsValid$ +
)+ ,
{ 

ErrorsResponse 
errors %
=& '
new( +
ErrorsResponse, :
(: ;
); <
;< =

StringBuilder 
errorMessage *
;* +
foreach 
( 
var 

modelState &
in' )
context* 1
.1 2

ModelState2 <
)< =
{ 

ErrorResponse !
error" '
=( )
new* -

ErrorResponse. ;
(; <
Guid< @
.@ A
NewGuidA H
(H I
)I J
.J K
ToStringK S
(S T
)T U
,U V

modelStateW a
.a b
Keyb e
)e f
;f g
if 
( 

modelState "
." #
Value# (
.( )
Errors) /
./ 0
Count0 5
>6 7
$num8 9
)9 :
{ 
errorMessage $
=% &
new' *

StringBuilder+ 8
(8 9
)9 :
;: ;
foreach 
(  
var  #
erro$ (
in) +

modelState, 6
.6 7
Value7 <
.< =
Errors= C
)C D
{ 
errorMessage   (
.  ( )
Append  ) /
(  / 0
erro  0 4
.  4 5
ErrorMessage  5 A
+  B C
$str  D H
)  H I
;  I J
}!! 
error"" 
."" 
Message"" %
=""& '
errorMessage""( 4
.""4 5
ToString""5 =
(""= >
)""> ?
;""? @
errors## 
.## 
Errors## %
.##% &
Add##& )
(##) *
error##* /
)##/ 0
;##0 1
}$$ 
}%% 
context'' 
.'' 
Result'' 
=''  
new''! $"
BadRequestObjectResult''% ;
(''; <
errors''< B
)''B C
;''C D
}(( 

base** 
.** 
OnActionExecuting** "
(**" #
context**# *
)*** +
;**+ ,
}++ 	
public-- 
override-- 
void-- 
OnActionExecuted-- -
(--- .!
ActionExecutedContext--. C
context--D K
)--K L
{.. 	
base00 
.00 Template
OnActionExecuted00 !
(00! "
context00" )
)00) *
;00* +
}11 	
}22 
}33 �^
xD:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.API\Controllers\PessoaController.cs
	namespace 	
Exemplo
 
. 
API 
. 
Controllers !
{ 
[ 
Route 

(
 
Template  
)  !
]! "
[ 

ApiController 
] 
public 
Template
class 
TemplateController !
:" #
Template
ApiController$ 1
{ 
private 
readonly 

ITemplateeAsync &
<& '
TemplateBuscaRequest' 9
,9 :
PessoaOutResponse; L
>L M"
_getPessoaUseCaseAsyncN d
Templated e
private 
readonly 

ITemplateeAsync &
<& '
Template
PessoaRequest' 4
,Template 5
PessoaOutResponse6 G
>G H
_pessoaUseCaseAsyncI \
Template\ ]
public 
PessoaController 
Template  

IUseCaseAsync  -
<- .
PessoaBuscaRequest. @
,@ A
PessoaOutResponseB S
>S T!
getPessoaUseCaseAsyncU j
,Templatek

IUseTemplateyncl y
<y z

PessoaRequest	z �
,
� �
PessoaOutResponse
� �
>
� � 
pessoaUseCaseAsync
� �
)
� �
{ 	"
_getPessoaUseCaseAsync "
=# $!
getPessoaUseCaseAsync% :
;: ;
_pessoaUseCaseAsync 
=  !
TemplateUseCaseAsync" 4
;4 5
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	
	Authorize	 
] 
[   	 
ProducesResponseType  	 
(   
typeof   $
(  $ %
PessoaOutResponse  % 6
)  6 7
,  7 8
StatusCodes  9 D
.  D E
Status200OK  E P
)  P Q
]  Q R
[!! 	 
ProducesResponseType!!	 
(!! 
typeof!! $
(!!$ %
ErrorsResponse!!% 3
)!!3 4
,!!4 5
StatusCodes!!6 A
.!!A B
Status400BadRequest!!B U
)!!U V
]!!V W
["" 	 
ProducesResponseType""	 
("" 
typeof"" $
(""$ %
ErrorsResponse""% 3
)""3 4
,""4 5
StatusCodes""6 A
.""A B
Status404NotFound""B S
)""S T
]""T U
[## 	 
ProducesResponseType##	 
(## 
typeof## $
(##$ %
ErrorsResponse##% 3
)##3 4
Template#4 5
StatusCodes##6 A
.##A B(
Status500InternalServerError##B ^
)##^ _
]##_ `
public$$ 
Template$$ 
Task$$ 
<$$ 

IActiTemplatelt$$ '
>$$' (
Get$$) ,
($$, -
[$$- .
	FromQuery$$. 7
]$$7 8
PessoaBuscaRequest$$9 K
request$$L S
)$$S T
{%% 	
try&& 
{'' 

using(( 
PessoaOutResponse(( '
pessoaOutResponse((( 9
=((: ;
await((< A"
_getPessoaUseCaseAsync((B X
.((X Y
ExecuteAsync((Y e
(((e f
request((f m
)((m n
;((n o
return)) 
Ok)) 
()) 
pessoaOutResponse)) +
)))+ ,
;)), -
}** 

catch++ 
(++ 
	Exception++ 
)++ 
{,, 

return.. 

StatusCode.. !
(..! "
$num.." %
,..% &
ControllerContext..' 8
Template.8 9

ModelState..9 C
)..C D
;..D E
}// 

}00 	
[22 	
HttpPost22	 
(22 
$str22 
)22 
]22 
[33 	
	Authorize33	 
]33 
[44 	 
ProducesResponseType44	 
(44 
typeof44 $
(44$ %
PessoaOutResponse44% 6
)446 7
,447 8
StatusCodes449 D
.44D E
Status200OK44E P
)44P Q
]44Q R
[55 	 
ProducesResponseType55	 
(55 
typeof55 $
(55$ %
ErrorsResponse55% 3
)553 4
,554 5
StatusCodes556 A
.55A B
Status400BadRequest55B U
)55U V
]55V W
[66 	 
ProducesResponseType66	 
(66 
typeof66 $
(66$ %
ErrorsResponse66% 3
)663 4
,664 5
StatusCodes666 A
.66A B
Status404NotFound66B S
)66S T
]66T U
[77 	 
ProducesResponseType77	 
Template7 
typeof77 $
(77$ %
ErrorsResponse77% 3
)773 4
,774 5
StatusCodes776 A
.77A B(
Status500InternalServerError77B ^
)77^ _
]77_ `
public88 
async88 
Task88 
<88 

IActionResult88 '
>88' (
Post88) -
(88- .
[88. /
FromBody88/ 7
]887 8

PessoaRequest889 F
request88G N
)88N O
{99 	
try:: 
{;; 

if<< 
(<< 
request<< 
==<< 
null<< #
||<<$ &
Templatet<<' .
.<<. /
Id<</ 1
!=<<2 4
$num<<5 6
||<<7 9
request<<: A
.<<A B
EAction<<B I
!=<<J L
Domain<<M S
.<<S T
Enum<<T X
.<<X Y
EAction<<Y `
.<<` a
INSERT<<a g
)<<g h
return== 

BadRequest== %
(==% &
)==& '
;==' (
using?? 
PessoaOutResponse?? '
pessoaOutResponse??( 9
=??: ;
await??< A
_pessoaUseCaseAsync??B U
.??U V
ExecuteAsync??V b
(??b c
request??c j
)??j k
;??k l
return@@ 
Ok@@ 
(@@ 
pessoaOutResponse@@ +
)@@+ ,
;@@, -
}AA 

catchBB 
(BB 
	ExceptionBB 
)BB 
{CC 

returnEE 
Template
StatusCodeEE !
(EE! "
$numEE" %
,EE% &
ControllerContextEE' 8
.EE8 9

ModelStateEE9 C
)EEC D
;EED E
}FF 

}GG 	
[II 	
HttpPutII	 
(II 
$strII 
)II 
]II 
[JJ 	
	AuthorizeJJ	 
]JJ 
[KK 	 
ProducesResponseTypeKK	 
(KK 
typeofKK $
(KK$ %
PessoaOutResponseKK% 6
)KK6 7
,KK7 8
StatusCodesKK9 D
.KKD E
Status200OKKKE P
)KKP Q
]KKQ R
[LL 	 
ProducesResponseTypeLL	 
(LL 
typeofLL $
(LL$ %
ErrorsResponseLL% 3
)LL3 4
,LL4 5
StatusCodesLL6 A
.LLA B
Status400BadRequestLLB U
)LLU V
]LLV W
[MM 	 
ProducesResponseTypeMM	 
(MM 
typeofMM $
(MM$ %
ErrorsResponseMM% 3
)MM3 4
,MM4 5
StatusCodesMM6 A
.MMA B
Status404NotFoundMMB S
)MMS T
TemplateMT U
[NN 	 
ProducesResponseTypeNN	 
(NN 
typeofNN $
(NN$ %
ErrorsResponseNN% 3
)NN3 4
,NN4 5
StatusCodesNN6 A
.NNA B(
Status500InternalServerErrorNNB ^
)NN^ _
]NN_ `
publicOO 
asyncOO 
TaskOO 
<OO 

IActionResultOO '
>OO' (
PutOO) ,
(OO, -
longOO- 1
idOO2 4
,OO4 5
[OO6 7
FromBodyOO7 ?
]OO? @

PessoaRequestOOA N
requestOOO V
)OOV W
{PP 	
tryQQ 
{RR 

TemplateS 
(SS 
requestSS 
==SS 
nullSS #
||SS$ &
requestSS' .
.SS. /
IdSS/ 1
!=SS2 4
idSS5 7
||SS8 :
requestSS; B
.SSB C
EActionSSC J
!=SSK M
DomainSSN T
.SST U
EnumSSU Y
.SSY Z
EActionSSZ a
.SSa b
UPDATESSb h
)SSh i
returnTT 

BadRequestTT %
(TT% &
)TT& '
;TT' (
usingVV 
PessoaOutResponseVV '
pessoaOutResponseVV( 9
=VV: ;
awaitVV< A
_pessoaUseCaseAsyncVVB U
.VVU V
ExecuteAsyncVVV b
(VVb c
requestVVc j
)VVj k
;VVk l
returnWW 
OkWW 
(WW 
pessoaOutResponseWW +
)WW+ ,
;WW, -
}XX 

catchYY 
(YY 
	TemplateionYY 
)YY 
{ZZ 

return\\ 

StatusCode\\ !
(\\! "
$num\\" %
,\\% &
ControllerContext\\' 8
.\\8 9

ModelState\\9 C
)\\C D
;\\D E
}]] 

}^^ 	
[`` 	

HttpDelete``	 
(`` 
$str`` 
)`` 
]`` 
[aa 	
	Authorizeaa	 
]aa 
[bb 	 
ProducesResponseTypebb	 
(bb 
typeofbb $
(bb$ %
PessoaOutResponsebb% 6
)bb6 7
,bb7 8
StatusCodesbb9 D
.bbD E
Status200OKbbE P
)bbP Q
]bbQ R
[cc 	 
ProducesResponseTypecc	 
(cc 
typeofcc $
(cc$ %
ErrorsResponsecc% 3
)cc3 4
,cc4 5
StatusCodescc6 A
.ccA B
Status400BadRequestccB U
)ccU V
]ccV W
[dd 	 
ProducesResponseTypedd	 
(dd 
typeofdd $
(dd$ %
ErrorsResponsedd% 3
Templated3 4
,dd4 5
StatusCodesdd6 A
.ddA B
Status404NotFoundddB S
)ddS T
]ddT U
[ee 	 
ProducesResponseTypeee	 
(ee 
typeofee $
(ee$ %
ErrorsResponseee% 3
)ee3 4
,ee4 5
StatusCodesee6 A
.eeA B(
Status500InternalServerErroreeB ^
)ee^ _
]ee_ `
publicff 
asyncff 
Taskff 
<ff 

IActionResultff '
>ff' (
Deleteff) /
(ff/ 0
longff0 4
idff5 7
,ff7 8
[ff9 :
FromBodyff: B
]ffB C

PessoaRequestffD Q
TemplatetffR Y
)ffY Z
{gg 	
tryhh 
{ii 

ifjj 
(jj 
requestjj 
==jj 
nulljj #
||jj$ &
requestjj' .
.jj. /
Idjj/ 1
!=jj2 4
idjj5 7
||jj8 :
requestjj; B
.jjB C
EActionjjC J
!=jjK M
DomainjjN T
.jjT U
EnumjjU Y
.jjY Z
EActionjjZ a
.jja b
DELETEjjb h
)jjh i
returnkk 

BadRequestkk %
(kk% &
)kk& '
;kk' (
usingmm 
PessoaOutResponsemm '
pessoaOutResponsemm( 9
=mm: ;
awaitmm< A
_pessoaUseCaseAsyncmmB U
.mmU V
ExecuteAsyncmmV b
(mmb c
requestmmc j
)mmj k
;mmk l
returnnn 
Oknn 
(nn 
pessoaOutResponsenn +
)nn+ ,
;nn, -
}oo 

catchpp 
(pp 
	Exceptionpp 
)pp 
{qq 

returnss 

StatusCodess !
(ss! "
$numss" %
,ss% &
ControllerContextss' 8
.ss8 9

ModelStatess9 C
)ssC D
;ssD E
}tt 

}uu 	
}vv 
}ww �
vD:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.API\Controllers\UserController.cs
	namespace

 	
Exemplo


 
.

 
API

 
.

 
Controllers

 !
{ 
[ 
Route 

(
 
$str  
)  !
]! "
[ 

ApiController 
] 
public 

class 
UserController 
:  !

ApiController" /
{ 
private 
readonly 

IUseCaseAsync &
<& '
UserRequest' 2
,2 3
UserOutResponse4 C
>C D'
_autenticarUserUseCaseAsyncE `
;` a
public 
UserController 
( 

IUseCaseAsync +
<+ ,
UserRequest, 7
,7 8
UserOutResponse9 H
>H I&
autenticarUserUseCaseAsyncJ d
)d e
{ 	'
_autenticarUserUseCaseAsync '
=( )&
autenticarUserUseCaseAsync* D
;D E
} 	
[ 	
HttpPost	 
( 
$str 
) 
]  
[ 	
AllowAnonymous	 
] 
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
UserOutResponse% 4
)4 5
,5 6
StatusCodes7 B
.B C
Status200OKC N
)N O
]O P
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
ErrorsResponse% 3
)3 4
,4 5
StatusCodes6 A
.A B
Status400BadRequestB U
)U V
]V W
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
ErrorsResponse% 3
)3 4
,4 5
StatusCodes6 A
.A B
Status404NotFoundB S
)S T
]T U
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
ErrorsResponse% 3
)3 4
,4 5
StatusCodes6 A
.A B(
Status500InternalServerErrorB ^
)^ _
]_ `
public   
async   
Task   
<   

IActionResult   '
>  ' (

Autenticar  ) 3
(  3 4
[  4 5
FromBody  5 =
]  = >
UserRequest  ? J
request  K R
)  R S
{!! 	
try"" 
{## 

using$$ 
($$ 
UserOutResponse$$ &
userOutResponse$$' 6
=$$7 8
await$$9 >'
_autenticarUserUseCaseAsync$$? Z
.$$Z [
ExecuteAsync$$[ g
($$g h
request$$h o
)$$o p
)$$p q
{%% 
return&& 
Ok&& 
(&& 
userOutResponse&& -
)&&- .
;&&. /
}'' 
}(( 

catch)) 
()) 
	Exception)) 
))) 
{** 

return,, 

StatusCode,, !
(,,! "
$num,," %
,,,% &
ControllerContext,,' 8
.,,8 9

ModelState,,9 C
),,C D
;,,D E
}-- 

}.. 	
}// 
}00 �

cD:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.API\Program.cs
	namespace

 	
Exemplo


 
.

 
API

 
{ 
public 

static 
class 
Program 
{

 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
} �<
cD:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.API\Startup.cs
	namespace 	
Exemplo
 
. 
API 
{ 
public 

class 
Startup 
{ 
readonly 
string "
MyAllowSpecificOrigins .
=/ 0
$str1 J
;J K
private 
static 

SwaggerConfig $
.$ %
Swagger% ,
swagger- 4
;4 5
public 
Startup 
( 
IConfiguration %

configuration& 3
)3 4
{ 	

Configuration 
= 

configuration )
;) *
swagger 
= 
new 

SwaggerConfig '
.' (
Swagger( /
(/ 0

configuration0 =
)= >
;> ?
} 	
public   
IConfiguration   

Configuration   +
{  , -
get  . 1
;  1 2
}  3 4
public## 
void## 
ConfigureServices## %
(##% &
IServiceCollection##& 8
services##9 A
)##A B
{$$ 	
services%% 
.%% 
AddCors%% 
(%% 
options%% $
=>%%% '
{&& 

options'' 
.'' 
	AddPolicy'' !
(''! "
name''" &
:''& '"
MyAllowSpecificOrigins''( >
,''> ?
builder((" )
=>((* ,
{))" #
builder**& -
.**- .
WithOrigins**. 9
(**9 :
$str+++ C
,,,* +
$str,,, @
,--* +
$str--, @
,..* +
$str.., @
)00* +
.00+ ,
AllowAnyOrigin00, :
(00: ;
)00; <
.00< =
AllowAnyMethod00= K
(00K L
)00L M
.00M N
AllowAnyHeader00N \
(00\ ]
)00] ^
;00^ _
}11" #
)11# $
;11$ %
}22 

)22
 
;22 
services44 
.44 
AddControllers44 #
(44# $
)44$ %
;44% &
Registry66 
.66 
RegisterApplication66 (
(66( )
services66) 1
)661 2
;662 3
Registry77 
.77 
RegisterDatabase77 %
(77% &
services77& .
)77. /
;77/ 0
services99 
.99 
RegisterAutoMapper99 '
<99' (
AutoMapperProfile99( 9
>999 :
(99: ;
)99; <
;99< =
var;; 
key;; 
=;; 
System;; 
.;; 
Text;; !
.;;! "
Encoding;;" *
.;;* +
ASCII;;+ 0
.;;0 1
GetBytes;;1 9
(;;9 :

Configuration;;: G
[;;G H
$str;;H W
];;W X
);;X Y
;;;Y Z
services== 
.== 
AddAuthentication== &
(==& '
x>> 
=>>> 
{?? 
x@@ 
.@@ %
DefaultAuthenticateScheme@@ 3
=@@4 5
JwtBearerDefaults@@6 G
.@@G H 
AuthenticationScheme@@H \
;@@\ ]
xAA 
.AA "
DefaultChallengeSchemeAA 0
=AA1 2
JwtBearerDefaultsAA3 D
.AAD E 
AuthenticationSchemeAAE Y
;AAY Z
}BB 
)CC 
.DD 
AddJwtBearerDD 
(DD 
xEE 
=>EE 
{FF 
xGG 
.GG  
RequireHttpsMetadataGG .
=GG/ 0
falseGG1 6
;GG6 7
xHH 
.HH 
	SaveTokenHH #
=HH$ %
trueHH& *
;HH* +
xII 
.II %
TokenValidationParametersII 3
=II4 5
newII6 9
	MicrosoftII: C
.IIC D

IdentityModelIID Q
.IIQ R
TokensIIR X
.IIX Y%
TokenValidationParametersIIY r
{JJ $
ValidateIssuerSigningKeyKK 4
=KK5 6
trueKK7 ;
,KK; <
IssuerSigningKeyLL ,
=LL- .
newLL/ 2 
SymmetricSecurityKeyLL3 G
(LLG H
keyLLH K
)LLK L
,LLL M
ValidateIssuerMM *
=MM+ ,
falseMM- 2
,MM2 3
ValidateAudienceNN ,
=NN- .
falseNN/ 4
}OO 
;OO 
}PP 
)PP 
;PP 
servicesSS 
.SS 

AddSwaggerGenSS "
(SS" #
cSS# $
=>SS% '
{TT 

cUU 
.UU 

SwaggerDocUU 
(UU 
swaggerUU $
.UU$ %

SwaggerDocUU% /
.UU/ 0
NameUU0 4
,UU4 5
newUU6 9
	MicrosoftUU: C
.UUC D
OpenApiUUD K
.UUK L
ModelsUUL R
.UUR S
OpenApiInfoUUS ^
{UU_ `
TitleUU` e
=UUf g
swaggerUUh o
.UUo p

SwaggerDocUUp z
.UUz {
OpenApiInfo	UU{ �
.
UU� �
Title
UU� �
,
UU� �
Version
UU� �
=
UU� �
swagger
UU� �
.
UU� �

SwaggerDoc
UU� �
.
UU� �
OpenApiInfo
UU� �
.
UU� �
Version
UU� �
}
UU� �
)
UU� �
;
UU� �
cVV 
.VV %
ResolveConflictingActionsVV +
(VV+ ,
apiDescriptionsVV, ;
=>VV< >
apiDescriptionsVV? N
.VVN O
FirstVVO T
(VVT U
)VVU V
)VVV W
;VVW X
}WW 

)WW
 
;WW 
}YY 	
public\\ 
void\\ 
	Configure\\ 
(\\ 
IApplicationBuilder\\ 1
app\\2 5
,\\5 6
IWebHostEnvironment\\7 J
env\\K N
)\\N O
{]] 	
if^^ 
(^^ 
env^^ 
.^^ 

IsDevelopment^^ !
(^^! "
)^^" #
)^^# $
{__ 

app`` 
.`` %
UseDeveloperExceptionPage`` -
(``- .
)``. /
;``/ 0
}aa 

appcc 
.cc 

UseSwaggercc 
(cc 
)cc 
;cc 
appdd 
.dd 
UseSwaggerUIdd 
(dd 
cdd 
=>dd !
cdd" #
.dd# $
SwaggerEndpointdd$ 3
(dd3 4
swaggerdd4 ;
.dd; <
SwaggerEndpointdd< K
.ddK L
UrlddL O
,ddO P
swaggerddP W
.ddW X
SwaggerEndpointddX g
.ddg h
Nameddh l
)ddl m
)ddm n
;ddn o
appff 
.ff 
UseHttpsRedirectionff #
(ff# $
)ff$ %
;ff% &
apphh 
.hh 

UseRoutinghh 
(hh 
)hh 
;hh 
appjj 
.jj 
UseCorsjj 
(jj "
MyAllowSpecificOriginsjj .
)jj. /
;jj/ 0
appll 
.ll 
UseAuthenticationll !
(ll! "
)ll" #
;ll# $
appnn 
.nn 
UseAuthorizationnn  
(nn  !
)nn! "
;nn" #
apppp 
.pp 
UseEndpointspp 
(pp 
	endpointspp &
=>pp' )
{qq 

	endpointsrr 
.rr 
MapControllersrr (
(rr( )
)rr) *
;rr* +
}ss 

)ss
 
;ss 
}tt 	
}uu 
}vv �
uD:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.API\SwaggerConfig\OpenApiInfo.cs
	namespace 	
Exemplo
 
. 
API 
. 

SwaggerConfig #
{ 
public 

class 
OpenApiInfo 
{		 
public

 
string

 
Title

 
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
}

( )
public 
string 
Version 
{ 
get  #
;# $
set% (
;( )
}* +
public 
OpenApiInfo 
( 
) 
{

 	
} 	
public 
OpenApiInfo 
( 
string !
title" '
,' (
string) /
version0 7
)7 8
{ 	
Title 
= 
title 
; 
Version 
= 
version 
; 
} 	
} 
} �
qD:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.API\SwaggerConfig\Swagger.cs
	namespace 	
Exemplo
 
. 
API 
. 

SwaggerConfig #
{ 
public		 

class		 
Swagger		 
{

 
public 

SwaggerDoc 

SwaggerDoc $
{% &
get' *
;* +
}, -
public 
SwaggerEndpoint 
SwaggerEndpoint .
{/ 0
get1 4
;4 5
}6 7
public 
Swagger 
( 
IConfiguration %

configuration& 3
)3 4
{ 	
OpenApiInfo 
openApiInfo #
=$ %
new& )
() *

configuration 
[  
$str  F
]F G
, 

configuration 
[  
$str  H
]H I
) 
; 
SwaggerEndpoint 
= 
new !
SwaggerEndpoint" 1
(1 2

configuration 
[  
$str  =
]= >
, 

configuration 
[  
$str  >
]> ?
, 

configuration 
[  
$str  A
]A B
) 
; 

SwaggerDoc 
= 
new 

SwaggerDoc '
(' (

configuration 
[  
$str  9
]9 :
, 
openApiInfo 
, 
SwaggerEndpoint !
) 
; 
}   	
}!! 
}"" �

tD:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.API\SwaggerConfig\SwaggerDoc.cs
	namespace 	
Exemplo
 
. 
API 
. 

SwaggerConfig #
{ 
public 

class 

SwaggerDoc 
{		 
public

 
string

 
Name

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
public 
OpenApiInfo 
OpenApiInfo &
{' (
get) ,
;, -
}. /
public 
SwaggerEndpoint 
SwaggerEndpoint .
{/ 0
get1 4
;4 5
}6 7
public 

SwaggerDoc 
( 
) 
{ 	
} 	
public 

SwaggerDoc 
( 
string  
name! %
,% &
OpenApiInfo' 2
openApiInfo3 >
,> ?
SwaggerEndpoint@ O
swaggerEndpointP _
)_ `
{ 	
Name 
= 
name 
; 
OpenApiInfo 
= 
openApiInfo %
;% &
SwaggerEndpoint 
= 
swaggerEndpoint -
;- .
} 	
} 
} �

yD:\GitHub\clodoaldozeferini\TestesGit\ASPNet\.NetCore\src\Exemplo\ServerSide\Exemplo.API\SwaggerConfig\SwaggerEndpoint.cs
	namespace 	
Exemplo
 
. 
API 
. 

SwaggerConfig #
{ 
public 

class 
SwaggerEndpoint  
{		 
public

 
string

 
Url

 
{

 
get

 
;

  
set

! $
;

$ %
}

& '
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Version 
{ 
get  #
;# $
set% (
;( )
}* +
public 
SwaggerEndpoint 
( 
)  
{ 	
} 	
public 
SwaggerEndpoint 
( 
string %
url& )
,) *
string+ 1
name2 6
,6 7
string8 >
version? F
)F G
{ 	
Url 
= 
url 
; 
Name 
= 
name 
; 
Version 
= 
version 
; 
} 	
} 
} 