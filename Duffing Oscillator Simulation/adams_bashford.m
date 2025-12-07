function [next_position, next_velocity] = adams_bashford(position_derivative, velocity_derivative, predictor_position, predictor_velocity, step_size, current_time, damping, drive, drive_frequency)

    [predictor_position_derivative, predictor_velocity_derivative] = derivative_function(predictor_position, predictor_velocity, (current_time+step_size), damping, drive, drive_frequency);
    next_position = (predictor_position_derivative + position_derivative)*0.5*step_size;
    next_velocity = (predictor_velocity_derivative + velocity_derivative)*0.5*step_size;
end
