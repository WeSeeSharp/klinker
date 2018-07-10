export interface AddSitterModel {
  firstName?: string | null;
  lastName?: string | null;
  hourlyRate?: number | null;
  hourlyRateBetweenBedtimeAndMidnight?: number | null;
  hourlyRateAfterMidnight?: number | null;
}