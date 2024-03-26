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
	
}

// Called every frame
void AProgCharacter::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

// Called to bind functionality to input
void AProgCharacter::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

}

