export interface SitterModel {
  id: number;
  firstName?: string;
  lastName?: string;
  hourlyRate?: number;
  hourlyRateBetweenBedtimeAndMidnight?: number;
  hourlyRateAfterMidnight?: number;
}