// Fill out your copyright notice in the Description page of Project Settings.


#include "CodedPawn.h"

// Sets default values
ACodedPawn::ACodedPawn()
{
 	// Set this pawn to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void ACodedPawn::BeginPlay()
{
	Super::BeginPlay();
	
}

// Called every frame
void ACodedPawn::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

// Called to bind functionality to input
void ACodedPawn::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

}

