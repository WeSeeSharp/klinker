export interface AddSitterModel {
  sitterId?: number;
  firstName?: string;
  lastName?: string;
  hourlyRate?: number;
  hourlyRateBetweenBedtimeAndMidnight?: number;
  hourlyRateAfterMidnight?: number;
}

export interface SitterModel extends AddSitterModel {
  id: number;
}
