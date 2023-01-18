
function [deriv_position, deriv_velocity] = derivative_function(position, velocity, current_time, damping, drive, drive_frequency)
    deriv_position = velocity;
    deriv_velocity = (position - position^3 - damping*velocity + drive*cos(drive_frequency*current_time));
end
