/// @description Insert description here
// You can write your code in this editor



//Get Player Input
keyUp = keyboard_check(ord("W"));
keyAttack = keyboard_check_pressed(vk_shift);

image_angle = point_direction(x,y,mouse_x,mouse_y) - 90;


if (keyUp){
	move_towards_point(mouse_x,mouse_y, speedFly);
}
