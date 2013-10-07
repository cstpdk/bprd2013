void arrsum(int n,int arr[],int *sump){
    int i; i = 0;

    int sum; sum=0;

    print n;println;

    while(i < n){
        sum = arr[i]+sum;
        i = i +1;
    }

    *sump = sum; 
}

int main(){
    int arr[100]; 
    int n;
    int *sump; sump=0;
    
    int i;i = 0;
    while(i < 100){
        arr[i] = i;
        i = i+1;
    }

    n = 10;
    arrsum(n,arr,sump);

    print *sump;println;
}
