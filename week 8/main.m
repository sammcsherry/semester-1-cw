clear;
number_of_particles = 7000;
step_size = 0.01;
total_time = 100;
number_of_steps = cast(total_time/step_size, "int8");
damping = 0.1;
drive = 0.35;
drive_frequency = 1.4;
count = 1;
centre_position = 0.0;
centre_velocity = 0.0;
poincare_steps = cast(total_time/drive_frequency, "int8");

particle_array = particle.empty(0, number_of_particles);
particle_array = create_particle_array(number_of_particles, centre_position, centre_velocity, number_of_steps, poincare_steps, particle_array);

old_position_derivative = 0;
old_velocity_derivative = 0;


grid = grid_matrix(300,300,5);
grid.matrix;

for particle_index = 1:number_of_particles
    count = 1;
    for current_time = 0:step_size:total_time-step_size 

        current_position = particle_array(particle_index).position(count);
        current_velocity = particle_array(particle_index).velocity(count);

        [position_derivative, velocity_derivative] = derivative_function(current_position, current_velocity, current_time, damping, drive, drive_frequency);
        
        predictor_position = current_position + position_derivative*1.5*step_size - old_position_derivative*0.5*step_size;
        predictor_velocity = current_velocity + velocity_derivative*1.5*step_size - old_velocity_derivative*0.5*step_size;

        [new_position, new_velocity] = adams_bashford(position_derivative, velocity_derivative, predictor_position, predictor_velocity, step_size, current_time, damping, drive, drive_frequency);
    
        particle_array(particle_index).position(count+1) = current_position + new_position;
        particle_array(particle_index).velocity(count+1) = current_velocity + new_velocity;
        new_position;

        %poincare
        if (mod(current_time, ((2*pi)/drive_frequency)) < 0.01) && current_time>(10*drive_frequency)
            particle_array(particle_index).poincare_position(count+1) = current_position;
            particle_array(particle_index).poincare_velocity(count+1) = current_velocity;
        end
    
        old_position_derivative = position_derivative;
        old_velocity_derivative = velocity_derivative;
    
        count = count+1;
    end

    %monte carlo
    final_position = particle_array(particle_index).position(end);
    final_velocity = particle_array(particle_index).velocity(end);
    grid.matrix = grid.add_plot(final_position, final_velocity);
end



%particle_array(particle_index).poincare_position;
%figure()
%plot(particle_array(particle_index).position, particle_array(particle_index).velocity);
%scatter(particle_array(1).poincare_position, particle_array(1).poincare_velocity, 2, 'filled');
figure()
%particle_phase_space_plot(particle_array);
heatmap(grid.matrix, 'Colormap', turbo);
%colorbar off
%grid off



