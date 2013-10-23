void main(){
    int month;
    month = 1;

    int y;
    y = 2004;

    switch (month) {
        case 1:
            {days = 31;}
        case 2:
            {days = 28; if (y%4==0) days=29;}
        case 3:
            {days = 31;}
    }
}
