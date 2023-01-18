classdef particle
    properties
        current_position;
        current_velocity;
        position
        velocity
        poincare_position;
        poincare_velocity;
    end
    methods 
        function obj = particle(number_of_steps, poincare_steps, initial_position, initial_velocity, number_of_coordinates)
            current_conditions = [initial_position, initial_velocity];
            obj.position = zeros(number_of_steps,0);
            obj.velocity = zeros(number_of_steps,0);
            obj.poincare_position = zeros(poincare_steps,0);
            obj.poincare_velocity = zeros(poincare_steps,0);
            obj.position(1) = initial_position;
            obj.velocity(1) = initial_velocity;
        end
    end
end


