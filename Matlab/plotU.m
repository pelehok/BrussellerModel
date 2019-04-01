x=0:0.1:1;
M=dlmread('resultV.txt');
y=M(:,1);
figure
plot(x,y)