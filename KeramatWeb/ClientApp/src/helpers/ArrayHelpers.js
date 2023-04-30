export const arrayRange = (start, stop, step = 1) =>
	Array.from({ length: (stop - start) / step + 1 }, (value, index) => start + index * step);
