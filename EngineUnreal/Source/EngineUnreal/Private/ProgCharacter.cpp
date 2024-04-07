// Fill out your copyright notice in the Description page of Project Settings.


#include "ProgCharacter.h"

// Sets default values
AProgCharacter::AProgCharacter()
{
 	// Set this character to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void AProgCharacter::BeginPlay()
{
	Super::BeginPlay();

	check(GEngine != nullptr);

	// Display a debug message for five seconds. 
	// The -1 "Key" value argument prevents the message from being updated or refreshed.
	GEngine->AddOnScreenDebugMessage(-1, 5.0f, FColor::Red, TEXT("We are using FPSCharacter."));
}

// Called every frame
void AProgCharacter::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

	if (IsSprinting) {
		//GetCharacterMovement().walk
	}
	else {
		Speed = WalkSpeed;
	}
	FString FloatToString = FString::SanitizeFloat(Speed);
	GEngine->AddOnScreenDebugMessage(-1, 5.0f, FColor::Red, *FloatToString);
}

// Called to bind functionality to input
void AProgCharacter::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

	// Set up "movement" bindings.
	PlayerInputComponent->BindAxis("Vertical", this, &AProgCharacter::Vertical);
	PlayerInputComponent->BindAxis("Horizontal", this, &AProgCharacter::Horizontal);

	// Set up "look" bindings.
	PlayerInputComponent->BindAxis("MouseX", this, &AProgCharacter::LookVertical);
	PlayerInputComponent->BindAxis("MouseY", this, &AProgCharacter::LookHorizontal);

	// Set up "action" bindings.
	PlayerInputComponent->BindAction("Jump", IE_Pressed, this, &AProgCharacter::StartJump);
	PlayerInputComponent->BindAction("Jump", IE_Released, this, &AProgCharacter::StopJump);

	// Set up "sprint" bindings.
	PlayerInputComponent->BindAction("Sprint", IE_Pressed, this, &AProgCharacter::StartSprint);
	PlayerInputComponent->BindAction("Sprint", IE_Released, this, &AProgCharacter::StopSprint);

}

void AProgCharacter::Vertical(float Value)
{
	// Find out which way is "forward" and record that the player wants to move that way.
	//FVector Direction = FRotationMatrix(Controller->GetControlRotation()).GetScaledAxis(EAxis::X);
	FVector Direction = GetActorForwardVector();
	AddMovementInput(Direction, Value * Speed);
}

void AProgCharacter::Horizontal(float Value)
{
	// Find out which way is "right" and record that the player wants to move that way.
	//FVector Direction = FRotationMatrix(Controller->GetControlRotation()).GetScaledAxis(EAxis::Y);

	FVector Direction = GetActorRightVector();
	AddMovementInput(Direction, Value * Speed);
}

void AProgCharacter::LookVertical(float Value)
{
	AddControllerYawInput(Value);
}

void AProgCharacter::LookHorizontal(float Value)
{
	AddControllerPitchInput(Value);
}

void AProgCharacter::StartJump()
{
	bPressedJump = true;
}

void AProgCharacter::StopJump()
{
	bPressedJump = false;
}

void AProgCharacter::StartSprint()
{
	IsSprinting = true;
}

void AProgCharacter::StopSprint()
{
	IsSprinting = false;
	
}

