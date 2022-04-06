import * as React from "react"
import Svg, { Path } from "react-native-svg"

const AvatarIconSvg = (props) => (
	<Svg
		xmlns="http://www.w3.org/2000/svg"
		fill='none'
		viewBox="0 0 48 48"
		width={20} height={20}
		{...props}
	>
		<Path
			fill="#4CAF50"
			d="M29 33H19S8 34.986 8 46h32c0-10.975-11-13-11-13"
		></Path>
		<Path fill="#FF9800" d="M24 39L19 33 19 27 29 27 29 33z"></Path>
		<Path
			fill="#FFA726"
			d="M35 21a2 2 0 11-4 0 2 2 0 014 0m-18 0a2 2 0 10-4 0 2 2 0 004 0"
		></Path>
		<Path
			fill="#FFB74D"
			d="M33 15c0-7.635-18-4.971-18 0v7c0 4.971 4.028 9 9 9a9 9 0 009-9v-7z"
		></Path>
		<Path
			fill="#FF5722"
			d="M24 6c-6.075 0-10 4.926-10 11v2.286L16 21v-5l12-4 4 4v5l2-1.742V17c0-4.025-1.038-8.016-6-9l-1-2h-3z"
		></Path>
		<Path
			fill="#784719"
			d="M27 21a1.001 1.001 0 111 1c-.552 0-1-.449-1-1m-8 0a1.001 1.001 0 101-1c-.552 0-1 .449-1 1"
		></Path>
		<Path
			fill="#2E7D32"
			d="M29 33l-5 6-5-6s-.88.161-2.141.637l.603.645 5 6 .538.643V46h2v-5.075l.536-.643 5-6 .539-.664C29.85 33.156 29 33 29 33z"
		></Path>
	</Svg>
)



export default AvatarIconSvg
