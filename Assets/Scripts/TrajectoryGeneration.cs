using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NumSharp;

public class TrajectoryGeneration : MonoBehaviour
{
    ////Constants
    //const init_pos = np.zeros(7);
    //const max_vel = np.zeros(7) + 180;
    //const max_acc = np.zeros(7) + 1000;
    //const num_robots = 1; //usually 10
    //const num_joints = 7;

    //const bpm = 60;
    //const time = 60 / bpm;
    //const time_step = 0.001;

    //public void generate_trajectory(dances_arr, dances_time_arr, final_time) //TODO: Specify types
    //{
    //    //for robot in range(num_robots)
    //    for (int i = 0; i < num_robots; i++)
    //    {
    //        robot_loc = robot * num_joints;
    //        // robot_loc = robot
    //        // routine = dances_arr[robot_loc]
    //        // routine_time = dances_time_arr[robot_loc]
    //        routine = dances_arr[robot];
    //        routine_time = dances_time_arr[robot];

    //        //TODO: Change syntax
    //        num_elem = sum(len(x) for x in routine); 
    //        // joints_phase = np.zeros((7, 1 + int(num_elem / 7)))
    //        joints_phase = [];
    //        // joints_time = np.zeros((7, 1 + int(num_elem / 7)))
    //        joints_time = [];

    //        //for joint in range(num_joints)
    //        for (int j = 0; j < num_joints; j++)
    //        {
    //            phase_arr = np.array([]);
    //            time_arr = np.array([]);

    //            //for i in range(len(routine))
    //            for (int k = 0; k < routine.length; k++) //TODO: Double check routine iteration
    //            {
    //                // phase_arr.append(routine[i][joint])
    //                phase_arr = np.append(phase_arr, routine[i][joint]);
    //                // time_arr = np.append(time_arr, routine_time[i][joint])
                    
    //                //TODO: Fix syntax, specifically isinstance, collections, and array indexing
    //                if (isinstance(routine_time[i][joint], collections.sequence))
    //                { 
    //                    if (isinstance(routine_time[i][joint][:], collections.sequence))
    //                    { 
    //                        if (isinstance(routine_time[i][joint][:][:], collections.sequence))
    //                        { 
    //                            if (isinstance(routine_time[i][joint][:][:][:], collections.sequence))
    //                            {
    //                                time_arr = np.append(time_arr, routine_time[i][joint][:][:][:][:]);
    //                            }
    //                            else 
    //                            {
    //                                time_arr = np.append(time_arr, routine_time[i][joint][:][:][:]);
    //                            }
    //                        }        
    //                        else
    //                        {
    //                            time_arr = np.append(time_arr, routine_time[i][joint][:][:]);
    //                        }
    //                    }
    //                    else
    //                    {
    //                        time_arr = np.append(time_arr, routine_time[i][joint][:]);
    //                    }
    //                }
    //                else:
    //                    time_arr = np.append(time_arr, routine_time[i][joint])
    //            }
    //            reset_pos = -1 * sum(phase_arr)
    //            // phase_arr.append(reset_pos)
    //            phase_arr = np.append(phase_arr, reset_pos)
    //            // time_arr.append(final_time)
    //            time_arr = np.append(time_arr, final_time)

    //            // joints_phase[joint] = phase_arr
    //            joints_phase.append(phase_arr)

    //            // joints_time[joint] = np.around((time * time_arr), 3)
    //            //flat_time_arr = np.ravel(time_arr)
    //            round_time = np.around((time * time_arr), 3)
    //            joints_time.append(round_time)
    //        }
    //        time_sums = np.empty(len(joints_time))

    //        for i in range(len(joints_time)) :
    //            time_sums[i] = sum(joints_time[i])

    //        time_max = max(time_sums)
    //        time_points = int(time_max / time_step) + 1
    //        time_step_arr = np.arange(0, time_max, time_step)

    //        if robot == 0:
    //            trajectory = np.zeros((7 * num_robots, time_points))
    //            velocity = np.zeros(((7 * num_robots), time_points))

    //        for joint in range(num_joints) :
    //            phases = len(joints_phase[joint])
    //            ind = 0

    //            curr_pos = 0

    //            vel_0 = 0
    //            q_i = 0

    //            while ind < phases:
    //                q_f = q_i + joints_phase[joint][ind]
    //                t_total = joints_time[joint][ind]
    //                t = np.arange(0, t_total, time_step)
    //                q_dot_i = 0
    //                q_dot_f = 0
    //                q_dotdot_i = 0
    //                q_dotdot_f = 0

    //                a0 = q_i
    //                a1 = q_dot_i
    //                a2 = 0.5 * q_dotdot_i
    //                a3 = 1.0 / (2.0 * t_total * *3.0) * (20.0 * (q_f - q_i) - (8.0 * q_dot_f +
    //                                                                           12.0 * q_dot_i) * t_total - (3.0 * q_dotdot_f - q_dotdot_i) * t_total * *2.0)
    //                a4 = 1.0 / (2.0 * t_total * *4.0) * (30.0 * (q_i - q_f) + (14.0 * q_dot_f + 16.0 *
    //                                                                           q_dot_i) * t_total + (3.0 * q_dotdot_f - 2.0 * q_dotdot_i) * t_total * *2.0)
    //                a5 = 1.0 / (2.0 * t_total * *5.0) * (12.0 * (q_f - q_i) - (6.0 * q_dot_f +
    //                                                                           6.0 * q_dot_i) * t_total - (q_dotdot_f - q_dotdot_i) * t_total * *2.0)

    //                traj_grid = a0 + a1 * t + a2 * t * *2 + a3 * t * *3 + a4 * t * *4 + a5 * t * *5
    //                velocity_grid = a1 + 2 * a2 * t + 3 * a3 * \
    //                    t * *2 + 4 * a4 * t * *3 + 5 * a5 * t * *4

    //                p = joints_phase[joint][ind]
    //                t_a = joints_time[joint][ind] / 2
    //                a = (p - vel_0 * t_a) / (t_a * *2)
    //                vf = t_a * a

    //                //if abs(a) > max_acc[joint] or abs(vf) > max_vel[joint]
    //                //rip = ['too fast at phase ', num2str(i), ' joint ', num2str(j),' velocity ',num2str(vf),' acceleration ',num2str(a)]

    //    new_pos = curr_pos + len(traj_grid)
    //                check = trajectory[((robot_loc) + joint), curr_pos: new_pos]
    //                trajectory[((robot_loc) + joint), curr_pos: new_pos] = traj_grid
    //                velocity[((robot_loc) + joint),
    //                         curr_pos: new_pos] = velocity_grid

    //                curr_pos = new_pos
    //                q_i = q_i + joints_phase[joint][ind]
    //                ind += 1

    //    }
    //    return trajectory, velocity
    //}
}
