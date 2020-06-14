program wheel;
var                     
    ft:text;            
    n,a,b,k,i,x,v:integer;
    sekt: array[1..100] of integer;
BEGIN
Assign(ft,'wheel.in');
Reset(ft);            
Readln(ft,n);
for i:=1 to n-1 do Read(ft,sekt[i]);
Readln(ft,sekt[n]);
Read(ft,a); 
Read(ft,b);
Read(ft,k);
close(ft);
x:=sekt[1];
repeat
v:=(a div k) mod n;
if sekt[v]<sekt[n-v+1] then v:=n-v+1;
if x<sekt[v] then x:=sekt[v];
a:=a+k;
until a>=b;
Assign(ft,'wheel.out');
Rewrite(ft);           
writeln(ft,x);      
close(ft);          
END.
