clc;  clear all;
fid=fopen('C:/Users/peleh/source/repos/BrussellerModel/BrussellerModel/bin/Debug/result.txt');
i=1;
j=1;
isArea1 = 1;
while ~(feof(fid))
    m=fgetl(fid);
    if isempty(m)& isArea1==1
        isArea1 = 2;
    else if isArea1==1 & ~isempty(m)
            m=strrep(m,',','.');
            a(i,:)=str2num(m);
            i=i+1;
        else if ~isempty(m)
            m=strrep(m,',','.');
            t = str2num(m);
            %if t(1,1) > 1
                b(j,:)=t;
                j=j+1;
            %end
            end
         end
    end
end
fclose(fid);
%a(i,:) = [2.5,0,0];
%a(i+1,:) = [2.5,2,0];
disp(a);
x=a(:,1);
y=a(:,2);
z=a(:,3);
[qx,qy] = meshgrid(linspace(min(x),max(x)),linspace(min(y),max(y)));
F = TriScatteredInterp(x,y,z);
qz = F(qx,qy);
%figure(1)
m = surf(qx,qy,qz);hold on;

disp(b);
xb=b(:,1);
yb=b(:,2);
zb=b(:,3);
[qxb,qyb] = meshgrid(linspace(min(xb),max(xb)),linspace(min(yb),max(yb)));
Fb = TriScatteredInterp(xb,yb,zb);
qzb = Fb(qxb,qyb);
%figure(2)
m = surf(qxb,qyb,qzb);

