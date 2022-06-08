int start = 1;
int end = 100;
for (int i = start; i<=end; i++){
    if (i % 5 == 0 && i % 3 == 0){
        i++;}
    else if(i % 3 == 0 | i % 5 == 0){
        Console.WriteLine(i);}
}
