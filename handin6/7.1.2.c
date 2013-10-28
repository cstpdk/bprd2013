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

void squares(int n, int arr[]){
    int i; i = 0;
    int y; y = 0;
    while(i < n){
        y = i*i;
        arr[i] = y;
        i = i+1;
    }
}

int main(){
    int arr[20]; 
    int *sump; sump=0;
    
    squares(20,arr);
    arrsum(10,arr,sump);

    print *sump;println;
}
