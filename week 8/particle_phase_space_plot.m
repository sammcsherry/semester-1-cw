function particle_phase_space_plot(particle_array)
figure();
 hold on
    for particle_index = 1:3
        plot(particle_array(particle_index).position, particle_array(particle_index).velocity);
    end

end