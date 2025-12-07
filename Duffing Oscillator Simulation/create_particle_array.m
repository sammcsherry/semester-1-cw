function particle_array = create_particle_array(number_of_particles, centre_position, centre_velocity, number_of_steps, poincare_steps, particle_array)
    for particle_index = 1:number_of_particles
        [radius, angle] = random_gaussian_plot();
        position_offset = radius*cos(angle);
        velocity_offset = radius*sin(angle);
        particle_array(particle_index) = particle(number_of_steps, poincare_steps, (centre_position+position_offset), (centre_velocity+velocity_offset));
    end
    particle_array = particle_array
end
