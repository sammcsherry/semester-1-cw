function [radius, angle] = random_gaussian_plot()
    standard_div = 0.01;
    radius = standard_div.*randn(1);
    angle = rand(1)*(180);
end