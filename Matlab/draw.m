clc;  clear all;
fid=fopen('C:/Users/peleh/source/repos/BrussellerModel/BrussellerModel/bin/Debug/result1.txt');
i=1;
while ~(feof(fid))
    m=fgetl(fid);
    if  ~isempty(m)
            m=strrep(m,',','.');
            a1(i,:)=str2num(m);
            i=i+1;
    end
end
fclose(fid);
%a(i,:) = [2.5,0,0];
%a(i+1,:) = [2.5,2,0];

x = 0:0.05:1;
t = 0:0.1:1;

figure
surf(x,t,a1)
title('u1(x,t)')
xlabel('Distance x')
ylabel('Time t')

fid=fopen('C:/Users/peleh/source/repos/BrussellerModel/BrussellerModel/bin/Debug/result2.txt');
i=1;
while ~(feof(fid))
    m=fgetl(fid);
    if  ~isempty(m)
            m=strrep(m,',','.');
            a2(i,:)=str2num(m);
            i=i+1;
    end
end
fclose(fid);

figure
surf(x,t,a2)
title('u2(x,t)')
xlabel('Distance x')
ylabel('Time t')