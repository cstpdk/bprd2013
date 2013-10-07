void histogram(int n, int ns[], int max, int freq[]){
    
    int i; i=0;
    int y; y=0;
    while(i<n){
        
        y = ns[i]; 
        freq[y] = freq[y]+1;

        i = i+1;
    }
}

void main(){

    int ns[7];
    ns[0] = 1;ns[1] = 2;ns[2] = 1;ns[3] = 1;
    ns[4] = 1;ns[5] = 2;ns[6] = 0;
    
    int freqs[4];
    int i;i=0;
    while(i<4){
        freqs[i]=0;
        i = i + 1;
    }
    print ns;
    //freq(7,ns,3,freqs);
}
