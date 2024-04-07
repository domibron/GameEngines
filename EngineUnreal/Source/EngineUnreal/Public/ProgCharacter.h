// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Character.h"
#include "ProgCharacter.generated.h"

UCLASS()
class ENGINEUNREAL_API AProgCharacter : public ACharacter
{
	GENERATED_BODY()

public:
	// Sets default values for this character's properties
	AProgCharacter();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	// Called to bind functionality to input
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;

	// Handles input for moving forward and backward.
	UFUNCTION()
	void Vertical(float Value);

	// Handles input for moving right and left.
	UFUNCTION()
	void Horizontal(float Value);

	UFUNCTION()
	void LookVertical(float Value);

	UFUNCTION()
	void LookHorizontal(float Value);

	// Sets jump flag when key is pressed.
	UFUNCTION()
	void StartJump();

	// Clears jump flag when key is released.
	UFUNCTION()
	void StopJump();

	// When player starts sprinting
	UFUNCTION()
	void StartSprint();

	// when player stops sprintin
	UFUNCTION()
	void StopSprint();

	float Speed = 2.0f;
	float WalkSpeed = 2.0f;
	float RunSpeed = 666.0f;

	bool IsSprinting = false;
};
