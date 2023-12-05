/// @description Insert description here
// You can write your code in this editor



//Get Player Input
keyUp = keyboard_check(ord("W"));
keyDown = keyboard_check(ord("S"));
keyLeft = keyboard_check(ord("A"));
keyRight = keyboard_check(ord("D"));
keyAttack = keyboard_check_pressed(vk_shift);

image_angle = point_direction(x,y,mouse_x,mouse_y) - 90;


if (keyUp){
	motion_add(image_angle+90, speedFly);
}
if (keyDown){
	motion_add(image_angle-90, speedFlyDirectionalScalar);
}
if (speed > 5){
	speed = 5;	
}

move_wrap(room_width,room_height,1);