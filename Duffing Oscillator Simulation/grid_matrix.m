classdef grid_matrix
    
    properties
        matrix;
        cell_length;

    end

    methods
        function obj = grid_matrix(number_of_rows, number_of_columns, length)
            obj.matrix = zeros(number_of_rows, number_of_columns);
            obj.cell_length = length/number_of_columns;
        end

        function matrix = add_plot(obj, position, velocity)

            position_index = floor(position/obj.cell_length + size(obj.matrix,1)/2);
            velocity_index = floor(velocity/obj.cell_length + size(obj.matrix,2)/2);
            obj.matrix(position_index, velocity_index) = obj.matrix(position_index, velocity_index)  + 1;
            matrix = obj.matrix;
        end

        function plot_heat_map(obj)
            figure()
            heatmap(obj.matrix);
        end
    end
end