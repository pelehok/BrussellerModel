function pdex4
m = 0;
x = 0:0.05:1;
t = 0:0.1:1;

sol = pdepe(m,@pdex4pde,@pdex4ic,@pdex4bc,x,t);
u1 = sol(:,:,1);
u2 = sol(:,:,2);

figure
surf(x,t,u1)
title('u1(x,t)')
xlabel('Distance x')
ylabel('Time t')

figure
surf(x,t,u2)
title('u2(x,t)')
xlabel('Distance x')
ylabel('Time t')

% figure
% plot(x,u2(end,:))
% title('Solution at t = 1')
% xlabel('Distance x')
% ylabel('u(x,1)')

end

