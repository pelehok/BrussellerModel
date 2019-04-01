function [c,f,s] = pdex4pde(x,t,u,DuDx)
c = [1; 1]; 
f = [0.002; 0.002] .* DuDx; 
s = [1+u(1)*u(1)*u(2)-4.4*u(1); 3.4*u(1)-u(1)*u(1)*u(2)]; 
end

